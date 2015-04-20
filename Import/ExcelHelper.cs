using System;
using System.Collections.Generic;
using System;
using System.Text;

using System.Threading;

//引用各命名空间  
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace Import
{
    public class ExcelHelper
    {

        public ExcelHelper()
        { }

        /// <summary>
        /// 从excel获取数据。
        /// 支持Excel2003及2007版本。
        /// Excel首列为列名。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isUnchange">是否用于导入数据库,ture为可导入</param>
        /// <param name="isRepeat">是否取多表</param>
        /// <param name="columns">列名</param>
        /// <param name="newData">返回数据集</param>
        /// <returns></returns>
        public  void GetDataFromExcel(string path, bool isUnchange, bool isRepeat, string columns, ref DataTable newData)
        {

            string fileType = path.Substring(path.LastIndexOf("."));
            string connetionStr;

            //配置链接
            if (fileType == ".xls")//Excel2003
            {
                connetionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            }
            else//Excel2007
            {
                connetionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            }

            using (OleDbConnection oleConn = new OleDbConnection(connetionStr))
            {
                oleConn.Open();
                DataTable table = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string tablename;


                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tablename = table.Rows[i]["Table_Name"].ToString();
                    if (tablename.Contains("_"))//'_'开头的数据表多为一些宏命令的临时数据表
                    {
                        table.Rows.Remove(table.Rows[i]);
                    }
                }


                int tableCount;
                int startTable;

                if (isRepeat)
                {
                    startTable = 0;
                    tableCount = table.Rows.Count;
                }
                else
                {
                    startTable = 0;
                    tableCount = 1;
                }
                try
                {
                    for (int i = startTable; i < tableCount; i++)
                    {
                        tablename = table.Rows[i]["Table_Name"].ToString();

                        string strSql = "select " + columns + " from [" + tablename + "]";
                        OleDbDataAdapter oleAdapter = new OleDbDataAdapter(strSql, oleConn);

                        oleAdapter.AcceptChangesDuringFill = !isUnchange;

                        //把Excel数据填充给DataTable
                        if (newData != null)
                        {
                            oleAdapter.Fill(newData);
                        }
                        oleAdapter.Dispose();
                        removeEmpty(newData);

                    }

                }
                catch (Exception ex)
                {
                    newData.Dispose();
                    throw ex;

                }
                finally
                {
                    oleConn.Close();
                    oleConn.Dispose();

                }
            }
        }

        /// <summary>
        /// Excel转为Txt，保存列名，‘,’分割
        /// </summary>
        private void ExcelToTxt(string path, string columns, out int datacount)
        {
            DataTable table = new DataTable();
            try
            {
                GetDataFromExcel(path, false, true, columns, ref  table);
            }
            catch
            {
                throw new Exception("读取excel数据失败");
            }


            datacount = table.Rows.Count;
            string[] temp = path.Split('.');
            string[] column = columns.Split(',');

            StringBuilder dataLine;
            int dataLineLength;
            string data;
            try
            {
                FileStream fsTxtFile = new FileStream(path.Replace(temp[temp.Length - 1], "") + ".txt", FileMode.CreateNew, FileAccess.Write);
                StreamWriter swTxtFile = new StreamWriter(fsTxtFile, Encoding.GetEncoding("gb2312"));

                foreach (DataRow dr in table.Rows)
                {
                    dataLineLength = 0;
                    dataLine = new StringBuilder();
                    for (int i = 0; i < column.Length; i++)
                    {
                        data = dr[column[i]].ToString();
                        if (i == column.Length - 1)
                        {
                            dataLine.AppendFormat("\"{0}\"", data);

                        }
                        else
                        {
                            dataLine.AppendFormat("\"{0}\",", data);
                        }
                        dataLineLength += data.Length;
                    }

                    if (dataLineLength > 0)
                    {
                        swTxtFile.WriteLine(dataLine.ToString());
                    }
                }
            }
            catch
            {
                throw new Exception("数据格式转换出错。");
            }
        }
     
        protected DataTable removeEmpty(DataTable dt)
        {
            List<DataRow> removeList = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool bRowDataIsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        bRowDataIsNull = false;
                    }
                }
                if (bRowDataIsNull)
                {
                    removeList.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removeList.Count; i++)
            {
                dt.Rows.Remove(removeList[i]);
            }
            return dt;
        }



    }
}
