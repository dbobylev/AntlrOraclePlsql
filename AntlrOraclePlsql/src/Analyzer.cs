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
        /// <summary>
        /// Parse the SQL, PL/SQL
        /// </summary>
        /// <param name="file"></param>
        /// <param name="CharsExtended">Allow the use of national chars in variables names</param>
        /// <returns></returns>
        public static PlSqlParser.Sql_scriptContext Run(TextReader file, bool CharsExtended = false)
        {
            var input = new AntlrInputStream(file);

            PlSqlLexerBase lexer;
            if (CharsExtended)
                lexer = new PlSqlLexerCharsExtend(input);
            else
                lexer = new PlSqlLexer(input);

            var tokens = new CommonTokenStream(lexer);
            var parser = new PlSqlParser(tokens);

            var ErrorManager = new AntlrErrorManager();
            lexer.AddErrorListener(ErrorManager.lexerErrorListener);
            parser.AddErrorListener(ErrorManager.parserErrorListener);

            var sql_script = parser.sql_script();

            // Raise the parse errors
            ErrorManager.CheckErrors();

            return sql_script;
        }

        public static PlSqlParser.Sql_scriptContext Run(string filepath, bool CharsExtended = false)
        {
            PlSqlParser.Sql_scriptContext result;
            using (StreamReader sr = File.OpenText(filepath))
                result = Run(sr, CharsExtended);
            
            return result;
        }

        public static PlSqlParser.Sql_scriptContext RunUpperCase(string filepath, bool CharsExtended = false)
        {
            string tmpPath = filepath + ".tmp";
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                    using (StreamWriter sw = new StreamWriter(tmpPath))
                        while (sr.Peek() >= 0)
                            sw.WriteLine(sr.ReadLine().ToUpper());

                var result = Run(tmpPath, CharsExtended);
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
