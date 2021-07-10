using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NeoMLInteropWrapper
{
    public partial class DnnMathEngine
    {
#if LINUX
        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "DestroyMathEngine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyMathEngine(IntPtr mathEngine );
#endif
    }
}
