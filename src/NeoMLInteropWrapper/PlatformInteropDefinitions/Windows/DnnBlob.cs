using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public partial class DnnBlob
    {
#if WIN64 || WIN32        
        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "DestroyDnnBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyDnnBlob(IntPtr blob);
#endif    
    }
}
