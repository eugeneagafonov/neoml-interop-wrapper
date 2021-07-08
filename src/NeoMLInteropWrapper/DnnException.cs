using System;

namespace NeoMLInteropWrapper
{
    public class DnnException : Exception
    {
        internal DnnException(TDnnErrorType errorType, char[] msg) : base(new string(msg))
        {
            ErrorType = errorType;
        }

        public TDnnErrorType ErrorType { get; }
    }
}
