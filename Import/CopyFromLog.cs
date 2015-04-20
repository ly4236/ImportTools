using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Import
{

    public partial class CopyFromLog : Form
    {
        public CopyFromLog()
        {
            InitializeComponent();
            BindRegionCbox();
        }
        #region GUI操作
        private void ButtonStart()
        {
            foreach (Control c in this.Controls)
            {

                if (c is Button)
                {
                    c.Enabled = false;
                }
            }
        }


        private void ButtonComp()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.Enabled = true;
                }
            }

        }
        string Root = Application.StartupPath;
        private void BindRegionCbox()
        {

            DataSet ds = new DataSet();
            ds.ReadXml(Root + @"\region.xml", XmlReadMode.Auto);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["text"] = ds.Tables[0].Rows[i]["code"].ToString() + "  --  " + ds.Tables[0].Rows[i]["text"].ToString();
            }

            cbxRegionCode.DataSource = ds.Tables[0];
            cbxRegionCode.ValueMember = "code";
            cbxRegionCode.DisplayMember = "text";
        }

        #endregion
        private void btnSetPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.csv)|*.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fileDialog.FileName;

            }
        }

        private class LogInfo
        {
            public string regioncode { get; set; }
            public string path { get; set; }
        }
        private AppendMessage appendMessage;
        private void btnStart_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请输入路径!");
                return;
            }
            appendMessage = new AppendMessage(AppendLabel);
            LogInfo li = new LogInfo();
            li.path = txtPath.Text;
            DataRowView dr = cbxRegionCode.SelectedItem as DataRowView;
            li.regioncode = dr["code"].ToString();
            bgwImport.RunWorkerAsync(li);
        }

        private void bgwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            LogInfo li = e.Argument as LogInfo;
            StreamReader sr = new StreamReader(li.path);
            string content;
            string[] contents = new string[4];

            int count = 0;
            int rightcount = 0;

            string idcard;
            string oldregion;
            string newregion = li.regioncode;
            string oldpath;
            string newpath;
            string drive = @"f:\";

            string newroot;
            while ((content = sr.ReadLine()) != null)
            {
                count++;
                contents = content.Split(',');
                idcard = contents[0];
                oldregion = contents[3];
                oldpath = ERecordPath.GetERecordPath(idcard, "130523", drive);
                newpath = ERecordPath.GetERecordPath(idcard, newregion, drive);
                if (File.Exists(oldpath))
                {
                    if (!File.Exists(newpath))
                    {
                        newroot = Path.GetDirectoryName(newpath);
                        if (!Directory.Exists(newroot))
                        {
                            Directory.CreateDirectory(newroot);
                        }
                        rightcount++;
                        File.Move(oldpath, newpath);
                    }
                    else
                    {
                        File.Delete(oldpath);
                    }
                }
                lblStatus.Invoke(appendMessage, idcard + ":" + rightcount.ToString() + "/" + count);
            }

        }
        //显示状态信息
        private void AppendLabel(string msg)
        {
            this.lblStatus.Text = msg;
        }

    }
}
