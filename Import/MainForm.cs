using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Import
{
    public delegate void AppendMessage(string msg);

    public partial class MainForm : Form
    {
        private AppendMessage appendMessage;


        string Root = Application.StartupPath;
        public MainForm()
        {
            InitializeComponent();
            appendMessage = new AppendMessage(AppendLabel);
            ButtonComp();
            BindRegionCbox();
            BindDrivesCbox();
            rbnShidaidianzi.Enabled = true;
            // bgwLoading.RunWorkerAsync();

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

        private void BindDrivesCbox()
        {

            DataTable dt = new DataTable();
            //获取磁盘设备
            DriveInfo[] drives = DriveInfo.GetDrives();

            dt.Columns.Add("text");
            DataRow dr;
            //遍历磁盘
            foreach (DriveInfo drive in drives)
            {

                dr = dt.NewRow();
                dr["text"] = drive.Name;
                dt.Rows.Add(dr);
                //    "磁盘分区号：" + drive.Name + "盘" 

                //    + "\t\n" +
                //"磁盘格式：" + drive.DriveFormat + "\t\n" +
                //"磁盘品牌：" + drive.DriveType + "\t\n" +
                //"磁盘卷标：" + drive.VolumeLabel + "\t\n" +
                //"磁盘总容量" + drive.TotalSize + "\t\n" +
                //"磁盘空余容量：" + drive.TotalFreeSpace;
            }


            cbxDrives.DataSource = dt;
            // cbxRegionCode.ValueMember = "code";
            cbxDrives.DisplayMember = "text";
        }
        #endregion

        //type 0 东方红、 1 时代电子
        private class ErecordInfo
        {
            public string drive { get; set; }
            public string oldroot { get; set; }
            public string regioncode { get; set; }
            public int type { get; set; }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ErecordInfo ei = new ErecordInfo();
            ei.drive = cbxDrives.Text;
            ei.oldroot = txtPath.Text;
            DataRowView dr = cbxRegionCode.SelectedItem as DataRowView;
            ei.regioncode = dr["code"].ToString();

            if (rbnShidaidianzi.Checked)
            {
                ei.type = 1;
            }
            else
            {
                ei.type = 0;
            }
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("请输入路径!");
                return;
            }
            bgwImport.RunWorkerAsync(ei);
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                this.txtPath.Text = foldPath;
            }
        }
        #region Import

        private void bgwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            ErecordInfo ei = e.Argument as ErecordInfo;

            lblStatus.Invoke(appendMessage, "开始导入...");
            string idcard;

            //   SqlCommand cmd = new SqlCommand();

            //DataRowView dr = cbxRegionCode.SelectedItem as DataRowView;
            //string regioncode = dr["code"].ToString();
            //string drive = cbxDrives.Text;
            //string oldERecordRoot = txtPath.Text;

            string newpath;
            string newroot;


            int wuxianRegionCount = 0;
            int wuxianRootCount = 0;
            int wuxianCount = 0;
            int wuxianTotal = 0;


            int ageRegionCount = 0;
            int ageRootCount = 0;
            int ageCount = 0;
            int ageTotal = 0;

            int total = 0;
            StreamWriter sw = new StreamWriter("log.csv", true);
            Random rd = new Random();
            string region = "";
            int year;
            const int yearMax = 1965;
            string[] regions = new string[] { "市本级", "内丘电子档案-城镇职工-20671", "内丘新农保电子档案-时代提取-114987", "邢台县电子档案-时代提取-170512", "任县电子档案-时代提取-179537", "沙河档案交接分拣196038" };
            List<string> regionList = new List<string>();
            for (int i = 0; i < regions.Length; i++)
            {
                regionList.Add(regions[i]);
            }

            try
            {
                foreach (string path in Directory.EnumerateFiles(ei.oldroot + @"\", "*.jpg", SearchOption.AllDirectories))
                {
                    if (path.Split('\\').Length > 3)
                    {
                        idcard = Path.GetFileNameWithoutExtension(path).Trim();
                        year = Convert.ToInt32(idcard.Substring(6, 4));
                        region = path.Split('\\')[2];
                        if (year >= yearMax && !Idcard.CheckIDCard15(idcard))
                        {
                            if (region != path.Split('\\')[2])
                            {
                                ageRegionCount++;
                                ageCount = 0;
                                ageRootCount = 0;
                            }
                            if (ageCount == 5000)
                            {
                                ageCount = 0;
                                ageRootCount++;
                            }
                            newpath = ERecordPath.GetERecordPathTemp(ei.drive, "五十岁以下", region, ageRootCount.ToString(), idcard);
                            newroot = Path.GetDirectoryName(newpath);
                            if (!Directory.Exists(newroot))
                            {
                                Directory.CreateDirectory(newroot);
                            }
                            if (!File.Exists(newpath))
                            {
                                ageCount++;
                                ageTotal++;
                                File.Copy(path, newpath, true);
                                WriteLogToCSV(sw, idcard + "," + path + "," + region);// + ei.type.ToString() + "," + ei.regioncode);
                            }

                        }
                        //if (year < yearMax || Idcard.CheckIDCard15(idcard))
                        //{
                        //    if (region != path.Split('\\')[2])
                        //    {
                        //        ageRegionCount++;
                        //        ageCount = 0;
                        //        ageRootCount = 0;
                        //    }
                        //    if (ageCount == 5000)
                        //    {
                        //        ageCount = 0;
                        //        ageRootCount++;
                        //    }
                        //    newpath = ERecordPath.GetERecordPathTemp(ei.drive, "50岁和15位", region, ageRootCount.ToString(), idcard);
                        //    newroot = Path.GetDirectoryName(newpath);
                        //    if (!Directory.Exists(newroot))
                        //    {
                        //        Directory.CreateDirectory(newroot);
                        //    }
                        //    if (!File.Exists(newpath))
                        //    {
                        //        ageCount++;
                        //        ageTotal++;
                        //        File.Copy(path, newpath, true);
                        //        WriteLogToCSV(sw, idcard + "," + path + "," + region);// + ei.type.ToString() + "," + ei.regioncode);
                        //    }

                        //}
                        //else if (regionList.Contains(region) && Idcard.IsIdcard(idcard) && IsGet(rd))
                        //{
                        //    if (region != path.Split('\\')[2])
                        //    {
                        //        wuxianRegionCount++;
                        //        wuxianRootCount = 0;
                        //        wuxianCount = 0;
                        //    }
                        //    if (wuxianCount == 5000)
                        //    {
                        //        wuxianCount = 0;
                        //        wuxianRootCount++;
                        //    }

                        //    newpath = ERecordPath.GetERecordPathTemp(ei.drive, "五县抽调", region, wuxianRootCount.ToString(), idcard);
                        //    newroot = Path.GetDirectoryName(newpath);
                        //    if (!Directory.Exists(newroot))
                        //    {
                        //        Directory.CreateDirectory(newroot);
                        //    }
                        //    if (!File.Exists(newpath))
                        //    {
                        //        wuxianCount++;
                        //        wuxianTotal++;
                        //        File.Copy(path, newpath, true);
                        //        WriteLogToCSV(sw, idcard + "," + path + "," + region);// + ei.type.ToString() + "," + ei.regioncode);
                        //    }
                        //}

                        total++;
                        lblStatus.Invoke(appendMessage, "50岁：" + ageRegionCount + "/" + ageRootCount + "/" + ageCount + "/" + ageTotal +
                            "。\n五县:" + wuxianRegionCount + "/" + wuxianRootCount + "/" + wuxianCount + "/" + wuxianTotal + "\t" + "总数：" + total);
                    }

                }
                lblStatus.Invoke(appendMessage, "完成" + total);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sw.Close();
            }


        }


        private bool IsGet(Random rd)
        {
            if (rd.Next(19) == 17)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void WriteLogToCSV(StreamWriter sw, string msg)
        {
            sw.WriteLine(msg);
        }
        ///// <summary>
        ///// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        ///// using the provided parameters.
        ///// </summary>
        ///// <remarks>
        ///// e.g.:  
        /////  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        ///// </remarks>
        ///// <param name="connectionString">a valid connection string for a SqlConnection</param>
        ///// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        ///// <param name="commandText">the stored procedure name or T-SQL command</param>
        ///// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        ///// <returns>A SqlDataReader containing the results</returns>
        //public static SqlDataReader ExecuteReader(SqlConnection conn, string cmdText, params SqlParameter[] commandParameters)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    // we use a try/catch here because if the method throws an exception we want to 
        //    // close the connection throw code, because no datareader will exist, hence the 
        //    // commandBehaviour.CloseConnection will not work
        //    try
        //    {
        //        PrepareCommand(cmd, conn, null, cmdText, commandParameters);
        //        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Parameters.Clear();
        //        return rdr;
        //    }
        //    catch
        //    {
        //        conn.Close();
        //        throw;
        //    }
        //}
        ///// <summary>
        ///// Prepare a command for execution
        ///// </summary>
        ///// <param name="cmd">SqlCommand object</param>
        ///// <param name="conn">SqlConnection object</param>
        ///// <param name="trans">SqlTransaction object</param>
        ///// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        ///// <param name="cmdText">Command text, e.g. Select * from Products</param>
        ///// <param name="cmdParms">SqlParameters to use in the command</param>
        //private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();

        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;

        //    if (trans != null)
        //        cmd.Transaction = trans;

        //    cmd.CommandType = CommandType.Text;

        //    if (cmdParms != null)
        //    {
        //        foreach (SqlParameter parm in cmdParms)
        //            cmd.Parameters.Add(parm);
        //    }
        //}
        //private string sqlConn
        //{
        //    get { return ConfigurationManager.ConnectionStrings["Import.Properties.Settings.ERecordConnectionString"].ConnectionString; }
        //}


        ///// <summary>
        ///// 关闭sqlserver数据库
        ///// </summary>
        //public void CloseSql()
        //{
        //    if (conn.State != ConnectionState.Closed)
        //    {
        //        conn.Close();
        //    }
        //}


        //显示状态信息
        private void AppendLabel(string msg)
        {
            this.lblStatus.Text = msg;
        }

        #endregion



        //下载方法

        //var ret = new WebClient();
        //byte[] b = ret.DownloadData("http://localhost:6812/ERecord/Server.ashx?id=1");
    }
}
