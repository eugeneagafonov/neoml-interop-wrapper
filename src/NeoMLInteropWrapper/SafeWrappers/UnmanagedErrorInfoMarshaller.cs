using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NeoMLInteropWrapper
{
    internal static class UnmanagedErrorInfoMarshaller
    {
        private static int errorInfoStructureSize;

        static UnmanagedErrorInfoMarshaller()
        {
            var errorInfo = new CDnnErrorInfo()
            {
                Type = TDnnErrorType.DET_OK,
                Description = new char[512]
            };

            errorInfoStructureSize = Marshal.SizeOf(errorInfo);
        }

        internal static CDnnErrorInfoWrapper GetErrorInfoBuffer()
        {        
          IntPtr errorInfoBuffer = Marshal.AllocHGlobal(errorInfoStructureSize);
          return new CDnnErrorInfoWrapper(errorInfoBuffer);
        }
    }

    internal class CDnnErrorInfoWrapper : UnmanagedResourceHandle
    {
        internal CDnnErrorInfoWrapper(IntPtr unmanagedErrorInfoBuffer) : base(unmanagedErrorInfoBuffer)
        {
        }

        internal IntPtr GetBufferHandle()
        {
            return handle;
        }

        internal override void DeleteHandle()
        {
            Marshal.FreeHGlobal(handle);
        }
    }

}
