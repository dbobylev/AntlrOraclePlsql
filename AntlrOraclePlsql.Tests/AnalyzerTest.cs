using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AntlrOraclePlsql.Tests
{
    static class AnalyzerTest
    {
        [TestCase(ScriptSource.CaseXmlTableAlias, TestName = "Analyzer_Parse_NoErrors: XmlTable alias")]
        [TestCase(ScriptSource.CaseCollectionsExtend, TestName = "Analyzer_Parse_NoErrors: Collections multi Extend")]
        [TestCase(ScriptSource.CasePragmaExceptionInit, TestName = "Analyzer_Parse_NoErrors: Pragma Exception_init")]
        [TestCase(ScriptSource.CaseValuesRowType, TestName = "Analyzer_Parse_NoErrors: insert values Rowtype")]
        [TestCase(ScriptSource.CaseMemberOf, TestName = "Analyzer_Parse_NoErrors: not member of")]
        [TestCase(ScriptSource.CaseSimpleForest, TestName = "Analyzer_Parse_NoErrors: xmlforrest without AS")]
        [TestCase(ScriptSource.CaseThreeDot, TestName = "Analyzer_Parse_NoErrors: insert into variable")]
        [TestCase(ScriptSource.CaseIntoArray, TestName = "Analyzer_Parse_NoErrors: insert into collection")]
        public static void Analyzer_Parse_NoErrors(string sql)
        {
            var context = Analyzer.RunUpperCase(sql.Path());
        }
    }
}
