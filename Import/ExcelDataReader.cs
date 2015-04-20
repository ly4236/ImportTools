using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Excel;
using System.Data.OracleClient;
namespace Import
{
    public class ExcelDataReader
    {
        private static IExcelDataReader InitReader(string path, FileStream stream)
        {
            var file = new FileInfo(path);
            IExcelDataReader reader = null;
            if (file.Extension == ".xls")
            {
                reader = ExcelReaderFactory.CreateBinaryReader(stream);

            }
            else if (file.Extension == ".xlsx")
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            return reader;
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="FirstRowIsColumnName"></param>
        /// <returns></returns>
        public static void GetDataTableFromExcel(string path, bool FirstRowIsColumnName, out DataSet ds)
        {

            var file = new FileInfo(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                IExcelDataReader reader = InitReader(path, stream);
                if (reader == null)
                {
                    ds = null;
                    throw new Exception("错误的excel格式");
                }
                reader.IsFirstRowAsColumnNames = FirstRowIsColumnName;
                ds = reader.AsDataSet();
            }
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="FirstRowIsColumnName"></param>
        /// <returns></returns>
        public static string[] GetColumnName(string path, bool FirstRowIsColumnName, int rowNumbeOfColumnNamer)
        {

            var file = new FileInfo(path);
            string[] columnNames = null;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                IExcelDataReader reader = InitReader(path, stream);
                reader.Read();
                columnNames = new string[reader.FieldCount];
                if (FirstRowIsColumnName)
                {
                    for (int i = 1; i < rowNumbeOfColumnNamer; i++)
                    {
                        reader.Read();
                    }
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames[i] = reader.GetString(i);
                    }
                }
                else
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames[i] = string.Format("第" + i + "列");
                    }
                }

            }
            return columnNames;
        }

    }
}
