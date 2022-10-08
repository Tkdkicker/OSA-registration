using Effect.BusinessIntelligence;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OSA_registration
{
    public partial class Form1 : Form
    {
        #region Private fields

        private DataTable _table = new DataTable();
        private string _batch = "";
        private bool _closing = false;
        private bool _chosenBatchClosing = false;

        #endregion Private fields

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Form1_Shown

        /// <summary>
        /// When GUI first open ask the user to enter a batch then show DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="event"></param>
        private void Form1_Shown(object sender, EventArgs @event)
        {
            //Set the current batch to nothing
            CurrentBatchlbl.Text = "";

            //Get all usernames (Key) and firstnames + surnames (Value) from 'Effect.BusinessIntelligence' database
            Dictionary<string, string> users = GetUsers().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var first in users)
            {
                //Add all usernames (Key) in combobox
                UsernamesCmbx.Items.Add(first.Key);
            }

            //The batch shouldn't be filled in before you get asked
            if (!string.IsNullOrEmpty(_batch))
            {
                return;
            }

            BatchUserInput();

            //Define data table
            _table = new DataTable();
            _table.Columns.Add("Serial Number", typeof(string));

            //Assign the data table to the DataGrid
            OsaDataGrid.DataSource = _table;
        }

        #endregion Form1_Shown

        #region SendToWipBtn_Click

        private void SendToWipBtn_Click(object sender, EventArgs @event)
        {
            //Set the combobox text to bold to inform the user of choosing their wiptracker username before moving on
            if (string.IsNullOrEmpty(UsernamesCmbx.Text) || string.IsNullOrWhiteSpace(UsernamesCmbx.Text)
                || UsernamesCmbx.SelectedIndex < 0)
            {
                UsernamesCmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
                UsernamesCmbx.Text = "Choose your wiptracker username";
                return;
            }

            //Declare a list that converts the IEnumerable to a list and looks after the 'OsaDataGrid' values
            List<string> serial = OsaDataGrid.Rows.OfType<DataGridViewRow>()
                       .Where(x => x.Cells[0].Value != null)
                       .Select(x => x.Cells[0].Value.ToString().Trim())/*and trims the empty spaces*/
                       .ToList();

            try
            {
                SetOsaSerialNumbers(_batch, serial, UsernamesCmbx.Text);
            }
            catch (Exception allExceptions)
            {
                //Display the specified exception from the 'SetOsaSerialNumbers' function
                MessageBox.Show(allExceptions.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion SendToWipBtn_Click

        #region ChangeBatchBtn_Click

        /// <summary>
        /// When button is clicked batch is reset to null for the user to input a new one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="event"></param>
        private void ChangeBatchBtn_Click(object sender, EventArgs @event)
        {
            CurrentBatchlbl.Text = "";

            _batch = "";

            BatchUserInput();
        }

        #endregion ChangeBatchBtn_Click

        #region OsaDataGrid_CellValidating

        /// <summary>
        /// Whenever the cells are of the same show a message with the duplicated values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="validatingEvent"></param>
        private void OsaDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs validatingEvent)
        {
            // Enumerate all rows.
            for (int row = 0; row < _table.Rows.Count; row++)
            {
                // Check row is different and if contents are the same.
                if (row != validatingEvent.RowIndex && string.Equals(_table.Rows[row][validatingEvent.ColumnIndex], validatingEvent.FormattedValue))
                {
                    // Show message box and cancel.
                    MessageBox.Show("Item " + validatingEvent.FormattedValue + " already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validatingEvent.Cancel = true;
                    break;
                }
            }
        }

        #endregion OsaDataGrid_CellValidating

        #region UsernameCmbx_DropDown

        /// <summary>
        /// When the dropdown arrow is clicked the text is no longer bold.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="event"></param>
        private void UsernamesCmbx_DropDown(object sender, EventArgs @event)
        {
            UsernamesCmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
        }

        #endregion UsernameCmbx_DropDown

        #region Form1_FormClosing

        /// <summary>
        /// Check the user wanting to close the app after they have chosen a batch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="closingevent"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs closingevent)
        {
            if (closingevent.CloseReason == CloseReason.UserClosing && !_closing && _chosenBatchClosing == false)
            {
                closingevent.Cancel = MessageBox.Show("Are you sure you want to exit?", "Close application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No;
            }
            else
            {
                return;
            }

            // Set closing flag.
            _closing = !closingevent.Cancel;
        }

        #endregion Form1_FormClosing

        #region BatchUserInput

        /// <summary>
        /// Ask the user to enter a batch for the first time then they're able to change it.
        /// </summary>
        public void BatchUserInput()
        {
            _chosenBatchClosing = true;

            while (string.IsNullOrEmpty(_batch) || string.IsNullOrWhiteSpace(_batch))
            {
                _batch = Interaction.InputBox("Please enter shop order number", "Shop order").Trim();//Trim the entered batch

                if (string.IsNullOrEmpty(_batch))
                {
                    if (MessageBox.Show("You can't have an empty shop order number", "No input", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel
                        && _chosenBatchClosing == true)
                    {
                        Close();
                        return;
                    }
                }
            }
            //Assign the batch to the'CurrentBatchLbl' label
            CurrentBatchlbl.Text = _batch;

            _chosenBatchClosing = false;
            //Set this variable to false so the user doesn't get the message when exiting because of the 'No input' message above
        }

        #endregion BatchUserInput

        #region GetUsers

        /// <summary>
        /// Get users.
        /// </summary>
        /// <returns>Users.</returns>
        public IDictionary<string, string> GetUsers()
        {
            using (Tracking tracking = new Tracking())
            {
                return tracking.GetUsers();
            }
        }

        #endregion GetUsers

        #region SetOsaSerialNumbers

        /// <summary>
        /// Set OSA serial numbers.
        /// </summary>
        /// <param name="batch"> Batch.</param>
        /// <param name="serial"> Serial numbers.</param>
        public void SetOsaSerialNumbers(string batch, IEnumerable<string> serial, string user)
        {
            using (Tracking tracking = new Tracking())
            {
                tracking.SetOsaSerialNumbers(batch, serial, user);
            }

            MessageBox.Show("Osa's registered successfully");
        }

        #endregion SetOsaSerialNumbers
    }
}