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
    public partial class SqlImport : Form
    {
        public SqlImport()
        {
            InitializeComponent();
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] sqlTableNames = SqlHelper.GetColumnsInfo("caijishang2");

            Dictionary<string, string> tablenameChinEng = new Dictionary<string, string>();
            tablenameChinEng.Add("身份证", "idcard");
            tablenameChinEng.Add("采集商", "caijishang");
            tablenameChinEng.Add("行政区划", "region");

            DataTable dt;
            ExcelHelper eh = new ExcelHelper();
            string msg;
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\Administrator\Desktop\采集商区分", "*.xlsx", SearchOption.TopDirectoryOnly))
            {
                dt = new DataTable();
                DataColumn dc = new DataColumn("行政区划", Type.GetType("System.String"));
                dc.DefaultValue = Path.GetFileNameWithoutExtension(file);
                dt.Columns.Add(dc);
                eh.GetDataFromExcel(file, false, true, "*", ref  dt);


                SqlHelper.AddModels(dt, tablenameChinEng, out msg);

            }


        }
    }
}
