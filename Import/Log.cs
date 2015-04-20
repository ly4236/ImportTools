using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Import
{
    public class Log
    {

        /// <summary>
        /// 准备导入文件地址清单
        /// </summary>
        /// <returns>日志地址</returns>
        public static string OldFileList(string root)
        {
            string logPath = Application.StartupPath + "oldfile.txt";
            DirectoryInfo di = new DirectoryInfo(root);
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(root);
                foreach (var file in di.EnumerateFiles())
                {
                    sw.WriteLine(file.Name);
                }
            }

            return logPath;
        }

    }
}
