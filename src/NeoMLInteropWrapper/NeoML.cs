using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public static partial class NeoML
    {
        public static DnnBlob CreateBlob(this DnnMathEngine dnnMathEngine, TDnnBlobType type, int batchLength, int batchWidth, int height, int width, int depth, int channelCount)
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = CreateDnnBlob(dnnMathEngine.GetUnmanagedPointer(), type, batchLength, batchWidth, height, width, depth, channelCount, errorInfoBuffer);

            if (blobPointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return new DnnBlob(blobPointer);
        }

        public static Dnn CreateDnnFromBuffer(this DnnMathEngine dnnMathEngine, byte[] buffer)
        {
            using var pinnedByteBuffer = new PinnedBuffer<byte>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = CreateDnnFromBuffer(dnnMathEngine.GetUnmanagedPointer(), pinnedByteBuffer.PinnedPointer, buffer.Length, errorInfoBuffer);

            if (dnnPointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return new Dnn(dnnPointer);
        }

        public static Dnn CreateDnnFromOnnxBuffer(this DnnMathEngine dnnMathEngine, byte[] buffer)
        {
            using var pinnedByteBuffer = new PinnedBuffer<byte>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = CreateDnnFromOnnxBuffer(dnnMathEngine.GetUnmanagedPointer(), pinnedByteBuffer.PinnedPointer, buffer.Length, errorInfoBuffer);

            if (dnnPointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return new Dnn(dnnPointer);
        }

        public static byte[] GetByteData(this DnnBlob blob)
        {
            var buffer = new byte[blob.DataSizeInBytes];
            using PinnedBuffer<byte> pinnedByteBuffer = new PinnedBuffer<byte>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = blob.GetUnmanagedPointer();
            bool result = CopyFromBlob(pinnedByteBuffer.PinnedPointer, blobPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return buffer;
        }   
        
        public static float[] GetFloatData(this DnnBlob blob)
        {
            var buffer = new float[blob.DataSizeInBytes / sizeof(float)];
            using PinnedBuffer<float> pinnedFloatBuffer = new PinnedBuffer<float>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = blob.GetUnmanagedPointer();
            bool result = CopyFromBlob(pinnedFloatBuffer.PinnedPointer, blobPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return buffer;
        }

        public static int[] GetIntData(this DnnBlob blob)
        {
            var buffer = new int[blob.DataSizeInBytes / sizeof(int)];
            using PinnedBuffer<int> pinnedIntBuffer = new PinnedBuffer<int>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = blob.GetUnmanagedPointer();
            bool result = CopyFromBlob(pinnedIntBuffer.PinnedPointer, blobPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return buffer;
        }

        public static void SetData(this DnnBlob blob, byte[] buffer)
        {
            using PinnedBuffer<byte> pinnedByteBuffer = new PinnedBuffer<byte>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = blob.GetUnmanagedPointer();
            bool result = CopyToBlob(blobPointer, pinnedByteBuffer.PinnedPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }
        }

        public static void SetData(this DnnBlob blob, float[] buffer)
        {
            using var pinnedFloatBuffer = new PinnedBuffer<float>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = blob.GetUnmanagedPointer();
            bool result = CopyToBlob(blobPointer, pinnedFloatBuffer.PinnedPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }
        }

        public static void SetData(this DnnBlob blob, int[] buffer)
        {
            using var pinnedIntBuffer = new PinnedBuffer<int>(buffer);
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr blobPointer = blob.GetUnmanagedPointer();
            bool result = CopyToBlob(blobPointer, pinnedIntBuffer.PinnedPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }
        }

        public static DnnMathEngine CreateCPUMathEngineInstance(int threadCount = 0)
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr enginePointer = CreateCPUMathEngine(threadCount, errorInfoBuffer);

            if (enginePointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return new DnnMathEngine(enginePointer);
        }

        public static DnnMathEngine CreateGPUMathEngineInstance()
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr enginePointer = CreateGPUMathEngine(errorInfoBuffer);

            if (enginePointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return new DnnMathEngine(enginePointer);
        }
    }
}
