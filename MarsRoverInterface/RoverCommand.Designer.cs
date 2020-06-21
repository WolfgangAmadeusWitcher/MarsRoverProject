namespace MarsRoverInterface
{
    partial class RoverCommand
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
            this.btnImport = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.lblOutputHeader = new System.Windows.Forms.Label();
            this.gridRoverLog = new System.Windows.Forms.DataGridView();
            this.lblLogDisplay = new System.Windows.Forms.Label();
            this.colRoverId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoverLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(708, 403);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(80, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(609, 403);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(80, 35);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtBoxOutput
            // 
            this.txtBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxOutput.Location = new System.Drawing.Point(12, 52);
            this.txtBoxOutput.Multiline = true;
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.ReadOnly = true;
            this.txtBoxOutput.Size = new System.Drawing.Size(580, 159);
            this.txtBoxOutput.TabIndex = 1;
            // 
            // lblOutputHeader
            // 
            this.lblOutputHeader.AutoSize = true;
            this.lblOutputHeader.Location = new System.Drawing.Point(9, 18);
            this.lblOutputHeader.Name = "lblOutputHeader";
            this.lblOutputHeader.Size = new System.Drawing.Size(63, 17);
            this.lblOutputHeader.TabIndex = 2;
            this.lblOutputHeader.Text = "Output : ";
            // 
            // gridRoverLog
            // 
            this.gridRoverLog.AllowUserToAddRows = false;
            this.gridRoverLog.AllowUserToDeleteRows = false;
            this.gridRoverLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRoverLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoverLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoverId,
            this.colLogEntry});
            this.gridRoverLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRoverLog.Location = new System.Drawing.Point(12, 253);
            this.gridRoverLog.Name = "gridRoverLog";
            this.gridRoverLog.RowHeadersVisible = false;
            this.gridRoverLog.RowTemplate.Height = 24;
            this.gridRoverLog.Size = new System.Drawing.Size(580, 185);
            this.gridRoverLog.TabIndex = 3;
            // 
            // lblLogDisplay
            // 
            this.lblLogDisplay.AutoSize = true;
            this.lblLogDisplay.Location = new System.Drawing.Point(9, 223);
            this.lblLogDisplay.Name = "lblLogDisplay";
            this.lblLogDisplay.Size = new System.Drawing.Size(93, 17);
            this.lblLogDisplay.TabIndex = 4;
            this.lblLogDisplay.Text = "Rover Logs : ";
            // 
            // colRoverId
            // 
            this.colRoverId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRoverId.HeaderText = "Rover Id";
            this.colRoverId.Name = "colRoverId";
            this.colRoverId.Width = 90;
            // 
            // colLogEntry
            // 
            this.colLogEntry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLogEntry.HeaderText = "Log Entry";
            this.colLogEntry.Name = "colLogEntry";
            this.colLogEntry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RoverCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLogDisplay);
            this.Controls.Add(this.gridRoverLog);
            this.Controls.Add(this.lblOutputHeader);
            this.Controls.Add(this.txtBoxOutput);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnImport);
            this.Name = "RoverCommand";
            this.Text = "HepsiBurada Mars Rover";
            ((System.ComponentModel.ISupportInitialize)(this.gridRoverLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtBoxOutput;
        private System.Windows.Forms.Label lblOutputHeader;
        private System.Windows.Forms.DataGridView gridRoverLog;
        private System.Windows.Forms.Label lblLogDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoverId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogEntry;
    }
}

