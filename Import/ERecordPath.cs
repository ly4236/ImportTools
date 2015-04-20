using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Import
{
    public class ERecordPath
    {
        public static string GetERecordPath(string idcard, string regioncode, string drive)
        {
            StringBuilder path = new StringBuilder();
            path.Append(drive);
            string[] data = new string[4];
            string year = idcard.Substring(6, 4);
            data[0] = "erecord1";
            data[1] = regioncode;
            data[2] = year;
            data[3] = idcard + ".jpg";
            path.Append(Path.Combine(data));
            return path.ToString();
        }


        public static string GetERecordPathRandom(string drive, string region, string rootcount, string idcard)
        {
            StringBuilder path = new StringBuilder();
            path.Append(drive);
            string[] data = new string[4];
            data[0] = "erecord1";
            data[1] = region;
            data[2] = region + "-" + rootcount;
            data[3] = idcard + ".jpg";
            path.Append(Path.Combine(data));
            return path.ToString();
        }


        public static string GetERecordPathTemp(string drive,string root, string region, string rootcount, string idcard)
        {
            StringBuilder path = new StringBuilder();
            path.Append(drive);
            string[] data = new string[5];
            data[0] = "电子档案";
            data[1] = root;
            data[2] = region;
            data[3] = region + "-" + rootcount;
            data[4] = idcard + ".jpg";
            path.Append(Path.Combine(data));
            return path.ToString();
        }
    }
}
