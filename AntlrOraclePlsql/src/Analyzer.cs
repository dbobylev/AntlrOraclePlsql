using Antlr4.Runtime;
using AntlrOraclePlsql.ErrorHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AntlrOraclePlsql
{
    public class Analyzer
    {
        public static PlSqlParser.Sql_scriptContext Run(TextReader file)
        {
            var input = new AntlrInputStream(file);
            var lexer = new PlSqlLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PlSqlParser(tokens);

            var ErrorManager = new AntlrErrorManager();
            lexer.AddErrorListener(ErrorManager.lexerErrorListener);
            parser.AddErrorListener(ErrorManager.parserErrorListener);

            var sql_script = parser.sql_script();

            ErrorManager.CheckErrors();

            return sql_script;
        }

        public static PlSqlParser.Sql_scriptContext Run(string filepath)
        {
            PlSqlParser.Sql_scriptContext result;
            using (StreamReader sr = File.OpenText(filepath))
                result = Run(sr);
            
            return result;
        }

        public static PlSqlParser.Sql_scriptContext RunUpperCase(string filepath)
        {
            string tmpPath = filepath + ".tmp";
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                    using (StreamWriter sw = new StreamWriter(tmpPath))
                        while (sr.Peek() >= 0)
                            sw.WriteLine(sr.ReadLine().ToUpper());

                var result = Run(tmpPath);
                File.Delete(tmpPath);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                File.Delete(tmpPath);
            }
        }
    }
}
