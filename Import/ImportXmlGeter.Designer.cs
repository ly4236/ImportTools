namespace Import
{
    partial class ImportXmlGeter
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
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.cbxIsHaveColumnNames = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.cbxDataFile = new System.Windows.Forms.ComboBox();
            this.lblRowNumber = new System.Windows.Forms.Label();
            this.txtRowNumber = new System.Windows.Forms.TextBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.myListView1 = new Import.MyListView();
            this.SuspendLayout();
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(60, 10);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(100, 21);
            this.txtTableName.TabIndex = 0;
            // 
            // cbxIsHaveColumnNames
            // 
            this.cbxIsHaveColumnNames.AutoSize = true;
            this.cbxIsHaveColumnNames.Location = new System.Drawing.Point(166, 12);
            this.cbxIsHaveColumnNames.Name = "cbxIsHaveColumnNames";
            this.cbxIsHaveColumnNames.Size = new System.Drawing.Size(96, 16);
            this.cbxIsHaveColumnNames.TabIndex = 1;
            this.cbxIsHaveColumnNames.Text = "是否含有列名";
            this.cbxIsHaveColumnNames.UseVisualStyleBackColor = true;
            this.cbxIsHaveColumnNames.CheckedChanged += new System.EventHandler(this.cbxIsHaveColumnNames_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "表名：";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(323, 333);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(405, 333);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "生成";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "数据文件地址:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(99, 64);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(218, 21);
            this.txtPath.TabIndex = 6;
            // 
            // btnSetPath
            // 
            this.btnSetPath.Location = new System.Drawing.Point(323, 63);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(75, 23);
            this.btnSetPath.TabIndex = 7;
            this.btnSetPath.Text = "浏览";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // cbxDataFile
            // 
            this.cbxDataFile.FormattingEnabled = true;
            this.cbxDataFile.Location = new System.Drawing.Point(17, 101);
            this.cbxDataFile.Name = "cbxDataFile";
            this.cbxDataFile.Size = new System.Drawing.Size(121, 20);
            this.cbxDataFile.TabIndex = 9;
            this.cbxDataFile.Visible = false;
            this.cbxDataFile.SelectedIndexChanged += new System.EventHandler(this.cbListViewCombo_SelectedIndexChanged);
            this.cbxDataFile.SelectedValueChanged += new System.EventHandler(this.cbListViewCombo_SelectedValueChanged);
            this.cbxDataFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbListViewCombo_KeyPress);
            // 
            // lblRowNumber
            // 
            this.lblRowNumber.AutoSize = true;
            this.lblRowNumber.Location = new System.Drawing.Point(15, 38);
            this.lblRowNumber.Name = "lblRowNumber";
            this.lblRowNumber.Size = new System.Drawing.Size(65, 12);
            this.lblRowNumber.TabIndex = 10;
            this.lblRowNumber.Text = "列名位置：";
            this.lblRowNumber.Visible = false;
            // 
            // txtRowNumber
            // 
            this.txtRowNumber.Location = new System.Drawing.Point(86, 35);
            this.txtRowNumber.Name = "txtRowNumber";
            this.txtRowNumber.Size = new System.Drawing.Size(36, 21);
            this.txtRowNumber.TabIndex = 11;
            this.txtRowNumber.Text = "0";
            this.txtRowNumber.Visible = false;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(128, 38);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(17, 12);
            this.lblRow.TabIndex = 12;
            this.lblRow.Text = "行";
            this.lblRow.Visible = false;
            // 
            // myListView1
            // 
            this.myListView1.Location = new System.Drawing.Point(15, 91);
            this.myListView1.Name = "myListView1";
            this.myListView1.Size = new System.Drawing.Size(302, 393);
            this.myListView1.TabIndex = 8;
            this.myListView1.UseCompatibleStateImageBehavior = false;
            this.myListView1.Click += new System.EventHandler(this.myListView1_Click);
            this.myListView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myListView1_MouseUp);
            // 
            // ImportXmlGeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 496);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.txtRowNumber);
            this.Controls.Add(this.lblRowNumber);
            this.Controls.Add(this.cbxDataFile);
            this.Controls.Add(this.myListView1);
            this.Controls.Add(this.btnSetPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxIsHaveColumnNames);
            this.Controls.Add(this.txtTableName);
            this.Name = "ImportXmlGeter";
            this.Text = "ImportXmlGeter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.CheckBox cbxIsHaveColumnNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSetPath;
        private MyListView myListView1;
        private System.Windows.Forms.ComboBox cbxDataFile;
        private System.Windows.Forms.Label lblRowNumber;
        private System.Windows.Forms.TextBox txtRowNumber;
        private System.Windows.Forms.Label lblRow;
    }
}