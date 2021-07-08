using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public partial class Dnn
    {
#if WIN64 || WIN32

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "GetInputName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetInputName(IntPtr dnn, int index, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "GetOutputName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetOutputName(IntPtr dnn, int index, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "SetInputBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetInputBlob(IntPtr dnn, int index, IntPtr blob, IntPtr errorInfo);
        
        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "GetOutputBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetOutputBlob(IntPtr dnn, int index, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "DnnRunOnce", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool DnnRunOnce(IntPtr dnn, IntPtr errorInfo);      

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "DestroyDnn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyDnn(IntPtr dnn);
#endif
    }
}
