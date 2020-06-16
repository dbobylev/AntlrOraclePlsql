using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AntlrOraclePlsql.Tests
{
    static class AnalyzerTest
    {
        [TestCase(ScriptSource.CaseMemberOf)]
        [TestCase(ScriptSource.CaseSimpleForest)]
        [TestCase(ScriptSource.CaseThreeDot)]
        [TestCase(ScriptSource.CaseIntoArray)]
        public static void Analyzer_Parse_NoErrors(string sql)
        {
            var context = Analyzer.RunUpperCase(sql.Path());
        }
    }
}
