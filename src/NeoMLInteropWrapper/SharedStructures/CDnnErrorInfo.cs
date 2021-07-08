using System;
using System.Runtime.InteropServices;

namespace NeoMLInteropWrapper
{
#if WIN64 || WIN32
    [StructLayout(LayoutKind.Sequential)]
#endif
    public struct CDnnErrorInfo
    {
        public TDnnErrorType Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public char[] Description;
    }

#if WIN64 || WIN32
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CDnnMathEngineDesc
    {
        internal TDnnMathEngineType Type;
    }

#if WIN64 || WIN32
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CDnnBlobDesc
    {
	    internal IntPtr MathEngine; // the math engine for the blob
        internal TDnnBlobType Type; // the type of data in the blob
        internal int BatchLength; // sequence length
        internal int BatchWidth; // the number of sequences processed together
        internal int Height; // object height
        internal int Width; // object width
        internal int Depth; // object depth
        internal int ChannelCount; // the number of channels
        internal int DataSize; // the total blob size in bytes
    };

#if WIN64 || WIN32
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CDnnDesc
    {
	    internal IntPtr MathEngine; // the math engine for the network
        internal int InputCount; // the number of network inputs
        internal int OutputCount; // the number of network outputs
    };

    public enum TDnnErrorType
    {
        DET_OK = 0,
        DET_InternalError = 1,
        DET_NoAvailableGPU = 2,
        DET_NoAvailableCPU = 3,
        DET_InvalidParameter = 4,
        DET_RunDnnError = 5,
        DET_LoadDnnError = 6
    }

    public enum TDnnMathEngineType
    {
        MET_CPU = 0,
        MET_GPU = 1
    }

    public enum TDnnBlobType
    {
        DBT_Float = 1,
        DBT_Int = 2
    }    
}


