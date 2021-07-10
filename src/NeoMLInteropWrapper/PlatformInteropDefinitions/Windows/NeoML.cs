using System;
using System.Runtime.InteropServices;
using System.Security;


namespace NeoMLInteropWrapper
{
    public static partial class NeoML
    {
#if WIN64 || WIN32
        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CreateGPUMathEngine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateGPUMathEngine(IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CreateCPUMathEngine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateCPUMathEngine(int threadCount, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CreateDnnBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateDnnBlob(IntPtr mathEngine, TDnnBlobType type, int batchLength, int batchWidth, int height, int width, int depth, int channelCount, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CopyToBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool CopyToBlob(IntPtr blob, IntPtr sourceBuffer, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CopyFromBlob", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool CopyFromBlob(IntPtr targetBuffer, IntPtr blob, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CreateDnnFromBuffer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateDnnFromBuffer(IntPtr mathEngine, IntPtr buffer, int bufferSize, IntPtr errorInfo);

        [SuppressUnmanagedCodeSecurity, DllImport("NeoProxy", EntryPoint = "CreateDnnFromOnnxBuffer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateDnnFromOnnxBuffer(IntPtr mathEngine, IntPtr buffer, int bufferSize, IntPtr errorInfo);
#endif
    }
}
