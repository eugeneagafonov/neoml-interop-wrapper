using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public partial class Dnn
    {
#if LINUX
        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "GetInputName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetInputName(IntPtr dnn, int index, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "GetOutputName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetOutputName(IntPtr dnn, int index, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "SetInputBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetInputBlob(IntPtr dnn, int index, IntPtr blob, IntPtr errorInfo);
        
        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "GetOutputBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetOutputBlob(IntPtr dnn, int index, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "DnnRunOnce", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool DnnRunOnce(IntPtr dnn, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("libNeoProxy.so", EntryPoint = "DestroyDnn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyDnn(IntPtr dnn);
#endif
    }
}
