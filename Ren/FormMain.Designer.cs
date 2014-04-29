namespace Ren
{
    partial class FormMain
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
            this.pnlKnoppen = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.lbRename = new System.Windows.Forms.ListBox();
            this.ofdDialog = new System.Windows.Forms.OpenFileDialog();
            this.fbdDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlKnoppen.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKnoppen
            // 
            this.pnlKnoppen.Controls.Add(this.btnClear);
            this.pnlKnoppen.Controls.Add(this.btnOpen);
            this.pnlKnoppen.Controls.Add(this.btnRename);
            this.pnlKnoppen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlKnoppen.Location = new System.Drawing.Point(0, 571);
            this.pnlKnoppen.Name = "pnlKnoppen";
            this.pnlKnoppen.Size = new System.Drawing.Size(762, 30);
            this.pnlKnoppen.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(113, 3);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(100, 23);
            this.btnRename.TabIndex = 0;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.AllowDrop = true;
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(3, 2);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(371, 563);
            this.lbFiles.TabIndex = 1;
            this.lbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragDrop);
            this.lbFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragOver);
            this.lbFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbFiles_KeyDown);
            this.lbFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFiles_MouseDown);
            // 
            // lbRename
            // 
            this.lbRename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRename.FormattingEnabled = true;
            this.lbRename.Location = new System.Drawing.Point(388, 2);
            this.lbRename.Name = "lbRename";
            this.lbRename.Size = new System.Drawing.Size(371, 563);
            this.lbRename.TabIndex = 2;
            this.lbRename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbRename_KeyDown);
            // 
            // fbdDialog
            // 
            this.fbdDialog.ShowNewFolderButton = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(659, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 601);
            this.Controls.Add(this.lbRename);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.pnlKnoppen);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rename";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlKnoppen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlKnoppen;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.ListBox lbRename;
        private System.Windows.Forms.OpenFileDialog ofdDialog;
        private System.Windows.Forms.FolderBrowserDialog fbdDialog;
        private System.Windows.Forms.Button btnClear;
    }
}