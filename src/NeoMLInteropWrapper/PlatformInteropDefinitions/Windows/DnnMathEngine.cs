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
#if WIN64 || WIN32
        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "DestroyMathEngine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyMathEngine(IntPtr mathEngine );
#endif
    }
}
