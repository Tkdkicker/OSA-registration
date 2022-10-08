
namespace OSA_registration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SendToWipBtn = new System.Windows.Forms.Button();
            this.OsaDataGrid = new System.Windows.Forms.DataGridView();
            this.ChangeBatchBtn = new System.Windows.Forms.Button();
            this.UsernamesCmbx = new System.Windows.Forms.ComboBox();
            this.BatchTitleLbl = new System.Windows.Forms.Label();
            this.CurrentBatchlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OsaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SendToWipBtn
            // 
            this.SendToWipBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToWipBtn.Location = new System.Drawing.Point(104, 294);
            this.SendToWipBtn.Name = "SendToWipBtn";
            this.SendToWipBtn.Size = new System.Drawing.Size(114, 56);
            this.SendToWipBtn.TabIndex = 1;
            this.SendToWipBtn.Text = "Send";
            this.SendToWipBtn.UseVisualStyleBackColor = true;
            this.SendToWipBtn.Click += new System.EventHandler(this.SendToWipBtn_Click);
            // 
            // OsaDataGrid
            // 
            this.OsaDataGrid.AllowUserToResizeColumns = false;
            this.OsaDataGrid.AllowUserToResizeRows = false;
            this.OsaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OsaDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OsaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OsaDataGrid.Location = new System.Drawing.Point(3, 78);
            this.OsaDataGrid.Name = "OsaDataGrid";
            this.OsaDataGrid.RowHeadersWidth = 51;
            this.OsaDataGrid.Size = new System.Drawing.Size(306, 210);
            this.OsaDataGrid.TabIndex = 2;
            this.OsaDataGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.OsaDataGrid_CellValidating);
            // 
            // ChangeBatchBtn
            // 
            this.ChangeBatchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeBatchBtn.Location = new System.Drawing.Point(150, 39);
            this.ChangeBatchBtn.Name = "ChangeBatchBtn";
            this.ChangeBatchBtn.Size = new System.Drawing.Size(122, 33);
            this.ChangeBatchBtn.TabIndex = 3;
            this.ChangeBatchBtn.Text = "Change batch";
            this.ChangeBatchBtn.UseVisualStyleBackColor = true;
            this.ChangeBatchBtn.Click += new System.EventHandler(this.ChangeBatchBtn_Click);
            // 
            // UsernamesCmbx
            // 
            this.UsernamesCmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernamesCmbx.FormattingEnabled = true;
            this.UsernamesCmbx.Location = new System.Drawing.Point(12, 12);
            this.UsernamesCmbx.Name = "UsernamesCmbx";
            this.UsernamesCmbx.Size = new System.Drawing.Size(286, 21);
            this.UsernamesCmbx.TabIndex = 4;
            this.UsernamesCmbx.Text = "Choose your wiptracker username";
            this.UsernamesCmbx.DropDown += new System.EventHandler(this.UsernamesCmbx_DropDown);
            // 
            // BatchTitleLbl
            // 
            this.BatchTitleLbl.AutoSize = true;
            this.BatchTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchTitleLbl.Location = new System.Drawing.Point(9, 39);
            this.BatchTitleLbl.Name = "BatchTitleLbl";
            this.BatchTitleLbl.Size = new System.Drawing.Size(98, 17);
            this.BatchTitleLbl.TabIndex = 5;
            this.BatchTitleLbl.Text = "Current batch:";
            // 
            // CurrentBatchlbl
            // 
            this.CurrentBatchlbl.AutoSize = true;
            this.CurrentBatchlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentBatchlbl.Location = new System.Drawing.Point(9, 58);
            this.CurrentBatchlbl.Name = "CurrentBatchlbl";
            this.CurrentBatchlbl.Size = new System.Drawing.Size(125, 17);
            this.CurrentBatchlbl.TabIndex = 6;
            this.CurrentBatchlbl.Text = "BRX000068.014";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 356);
            this.Controls.Add(this.CurrentBatchlbl);
            this.Controls.Add(this.BatchTitleLbl);
            this.Controls.Add(this.UsernamesCmbx);
            this.Controls.Add(this.ChangeBatchBtn);
            this.Controls.Add(this.OsaDataGrid);
            this.Controls.Add(this.SendToWipBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSA registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.OsaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SendToWipBtn;
        private System.Windows.Forms.DataGridView OsaDataGrid;
        private System.Windows.Forms.Button ChangeBatchBtn;
        private System.Windows.Forms.ComboBox UsernamesCmbx;
        private System.Windows.Forms.Label BatchTitleLbl;
        private System.Windows.Forms.Label CurrentBatchlbl;
    }
}

