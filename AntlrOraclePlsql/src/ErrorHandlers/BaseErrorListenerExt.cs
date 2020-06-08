using System;
using System.Collections.Generic;
using System.Text;

namespace AntlrOraclePlsql.src.ErrorHandlers
{
    public delegate void PushMessageDelegate(string msg);

    abstract class BaseErrorListenerExt
    {
        public event PushMessageDelegate OnErrorOccured;

        public BaseErrorListenerExt() { }

        protected void PushAntlrError(string msg, int line, int pos)
        {
            OnErrorOccured?.Invoke($"{msg} (Line:{line} Col:{pos})");
        }
    }
}
