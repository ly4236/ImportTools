namespace Import
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.bgwImport = new System.ComponentModel.BackgroundWorker();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.bgwLoading = new System.ComponentModel.BackgroundWorker();
            this.cbxRegionCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDrives = new System.Windows.Forms.ComboBox();
            this.rbnDongfanghong = new System.Windows.Forms.RadioButton();
            this.rbnShidaidianzi = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择路径：";
            // 
            // bgwImport
            // 
            this.bgwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwImport_DoWork);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(72, 52);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(200, 21);
            this.txtPath.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 112);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 12);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "导入状态：请选择路径";
            // 
            // btnSetPath
            // 
            this.btnSetPath.Location = new System.Drawing.Point(279, 52);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(75, 23);
            this.btnSetPath.TabIndex = 5;
            this.btnSetPath.Text = "浏览";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // cbxRegionCode
            // 
            this.cbxRegionCode.FormattingEnabled = true;
            this.cbxRegionCode.Location = new System.Drawing.Point(72, 12);
            this.cbxRegionCode.Name = "cbxRegionCode";
            this.cbxRegionCode.Size = new System.Drawing.Size(200, 20);
            this.cbxRegionCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "行政区划：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "选择导入磁盘：";
            // 
            // cbxDrives
            // 
            this.cbxDrives.FormattingEnabled = true;
            this.cbxDrives.Location = new System.Drawing.Point(478, 11);
            this.cbxDrives.Name = "cbxDrives";
            this.cbxDrives.Size = new System.Drawing.Size(50, 20);
            this.cbxDrives.TabIndex = 10;
            // 
            // rbnDongfanghong
            // 
            this.rbnDongfanghong.AutoSize = true;
            this.rbnDongfanghong.Location = new System.Drawing.Point(569, 51);
            this.rbnDongfanghong.Name = "rbnDongfanghong";
            this.rbnDongfanghong.Size = new System.Drawing.Size(59, 16);
            this.rbnDongfanghong.TabIndex = 11;
            this.rbnDongfanghong.TabStop = true;
            this.rbnDongfanghong.Text = "东方红";
            this.rbnDongfanghong.UseVisualStyleBackColor = true;
            // 
            // rbnShidaidianzi
            // 
            this.rbnShidaidianzi.AutoSize = true;
            this.rbnShidaidianzi.Location = new System.Drawing.Point(478, 51);
            this.rbnShidaidianzi.Name = "rbnShidaidianzi";
            this.rbnShidaidianzi.Size = new System.Drawing.Size(71, 16);
            this.rbnShidaidianzi.TabIndex = 12;
            this.rbnShidaidianzi.TabStop = true;
            this.rbnShidaidianzi.Text = "时代电子";
            this.rbnShidaidianzi.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "选择数据来源：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 151);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbnShidaidianzi);
            this.Controls.Add(this.rbnDongfanghong);
            this.Controls.Add(this.cbxDrives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxRegionCode);
            this.Controls.Add(this.btnSetPath);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "电子档案导入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgwImport;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSetPath;
        private System.ComponentModel.BackgroundWorker bgwLoading;
        private System.Windows.Forms.ComboBox cbxRegionCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDrives;
        private System.Windows.Forms.RadioButton rbnDongfanghong;
        private System.Windows.Forms.RadioButton rbnShidaidianzi;
        private System.Windows.Forms.Label label4;
    }
}