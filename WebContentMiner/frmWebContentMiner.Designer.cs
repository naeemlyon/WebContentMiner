namespace WebContentMiner
{
    partial class frm_WebContentMiner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WebContentMiner));
            this.btn_Start = new System.Windows.Forms.Button();
            this.tbx_Root_Path = new System.Windows.Forms.TextBox();
            this.tbx_Display = new System.Windows.Forms.TextBox();
            this.lvw_Authors = new System.Windows.Forms.ListView();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.cbo_To = new System.Windows.Forms.ComboBox();
            this.cbo_From = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(512, 351);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(67, 40);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // tbx_Root_Path
            // 
            this.tbx_Root_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Root_Path.Location = new System.Drawing.Point(143, 23);
            this.tbx_Root_Path.Multiline = true;
            this.tbx_Root_Path.Name = "tbx_Root_Path";
            this.tbx_Root_Path.Size = new System.Drawing.Size(419, 33);
            this.tbx_Root_Path.TabIndex = 1;
            this.tbx_Root_Path.Text = "E:\\\\WebContentMinerDownloads";
            // 
            // tbx_Display
            // 
            this.tbx_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Display.ForeColor = System.Drawing.Color.MediumBlue;
            this.tbx_Display.Location = new System.Drawing.Point(9, 352);
            this.tbx_Display.Multiline = true;
            this.tbx_Display.Name = "tbx_Display";
            this.tbx_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Display.Size = new System.Drawing.Size(341, 36);
            this.tbx_Display.TabIndex = 95;
            // 
            // lvw_Authors
            // 
            this.lvw_Authors.BackColor = System.Drawing.Color.PowderBlue;
            this.lvw_Authors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader27});
            this.lvw_Authors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvw_Authors.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lvw_Authors.FullRowSelect = true;
            this.lvw_Authors.GridLines = true;
            this.lvw_Authors.HideSelection = false;
            this.lvw_Authors.Location = new System.Drawing.Point(9, 62);
            this.lvw_Authors.MultiSelect = false;
            this.lvw_Authors.Name = "lvw_Authors";
            this.lvw_Authors.Size = new System.Drawing.Size(567, 284);
            this.lvw_Authors.TabIndex = 96;
            this.lvw_Authors.UseCompatibleStateImageBehavior = false;
            this.lvw_Authors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Authors";
            this.columnHeader28.Width = 200;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Home Page";
            this.columnHeader27.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Download Directory Path";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(404, 381);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(45, 16);
            this.btn_Refresh.TabIndex = 111;
            this.btn_Refresh.Text = "\'\'\'\'\'\'\'\'\'\'";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // cbo_To
            // 
            this.cbo_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_To.FormattingEnabled = true;
            this.cbo_To.Location = new System.Drawing.Point(435, 351);
            this.cbo_To.Name = "cbo_To";
            this.cbo_To.Size = new System.Drawing.Size(60, 21);
            this.cbo_To.TabIndex = 110;
            // 
            // cbo_From
            // 
            this.cbo_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_From.FormattingEnabled = true;
            this.cbo_From.Location = new System.Drawing.Point(357, 352);
            this.cbo_From.Name = "cbo_From";
            this.cbo_From.Size = new System.Drawing.Size(59, 21);
            this.cbo_From.TabIndex = 109;
            // 
            // frm_WebContentMiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 401);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.cbo_To);
            this.Controls.Add(this.cbo_From);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvw_Authors);
            this.Controls.Add(this.tbx_Display);
            this.Controls.Add(this.tbx_Root_Path);
            this.Controls.Add(this.btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_WebContentMiner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Content Miner (naeem@email.com)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox tbx_Root_Path;
        private System.Windows.Forms.TextBox tbx_Display;
        private System.Windows.Forms.ListView lvw_Authors;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.ComboBox cbo_To;
        private System.Windows.Forms.ComboBox cbo_From;
    }
}

