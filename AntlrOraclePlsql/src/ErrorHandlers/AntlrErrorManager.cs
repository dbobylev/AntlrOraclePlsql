using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AntlrOraclePlsql.ErrorHandlers
{

    class AntlrErrorManager
    {
        private StringBuilder _ErrorsMessage;

        public LexerErrorListener lexerErrorListener { get; private set; }
        public ParserErrorListener parserErrorListener { get; private set; }

        public AntlrErrorManager()
        {
            _ErrorsMessage = new StringBuilder();

            lexerErrorListener = new LexerErrorListener();
            lexerErrorListener.OnErrorOccured += AddErrorMessage;

            parserErrorListener = new ParserErrorListener();
            parserErrorListener.OnErrorOccured += AddErrorMessage;
        }

        private void AddErrorMessage(string msg)
        {
            _ErrorsMessage.AppendLine(msg);
        }

        public void CheckErrors()
        {
            if (_ErrorsMessage.Length > 0)
                throw new Exception(_ErrorsMessage.ToString());
        }
    }
}
