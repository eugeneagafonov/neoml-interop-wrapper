using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public partial class DnnBlob
    {
#if LINUX
        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "DestroyDnnBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyDnnBlob(IntPtr blob);
#endif
    }
}
