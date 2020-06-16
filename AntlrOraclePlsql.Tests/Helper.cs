using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AntlrOraclePlsql.Tests
{
    public static class Helper
    {
        public static string Path(this string source)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp.sql");
            File.WriteAllText(filePath, source);
            return filePath;
        }
    }
}
