using Antlr4.Runtime;
using AntlrOraclePlsql.src.ErrorHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AntlrOraclePlsql.ErrorHandlers
{
    class ParserErrorListener : BaseErrorListenerExt, IAntlrErrorListener<IToken>
    {
        public ParserErrorListener() { }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            PushAntlrError(msg, line, charPositionInLine);
        }
    }
}
