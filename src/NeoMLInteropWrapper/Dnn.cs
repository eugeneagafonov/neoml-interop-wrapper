using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public partial class Dnn : UnmanagedResourceHandle
    {
        private CDnnDesc _dnnDesc;

        internal Dnn(IntPtr unmanagedDnn) : base(unmanagedDnn)
        {
            _dnnDesc = Marshal.PtrToStructure<CDnnDesc>(handle);
        }

        internal override void DeleteHandle()
        {
            DestroyDnn(handle);
        }

        public int InputCount => _dnnDesc.InputCount;

        public int OutputCount => _dnnDesc.OutputCount;

        public void RunOnce()
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = GetUnmanagedPointer();

            bool result = DnnRunOnce(dnnPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }
        }

        public void SetInputBlob(int index, DnnBlob blob)
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = GetUnmanagedPointer();
            IntPtr blobPointer = blob.GetUnmanagedPointer();

            bool result = SetInputBlob(dnnPointer, index, blobPointer, errorInfoBuffer);

            if (!result)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }
        }

        public DnnBlob GetOutputBlob(int index)
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = GetUnmanagedPointer();
            IntPtr blobPointer = GetOutputBlob(dnnPointer, index, errorInfoBuffer);

            if (blobPointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return new DnnBlob(blobPointer);
        }

        public string GetInputName(int index)
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = GetUnmanagedPointer();
            IntPtr charArrayPointer = GetInputName(dnnPointer, index, errorInfoBuffer);

            if (charArrayPointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return Marshal.PtrToStringAnsi(charArrayPointer);
        }

        public string GetOutputName(int index)
        {
            using CDnnErrorInfoWrapper errorInfoWrapper = UnmanagedErrorInfoMarshaller.GetErrorInfoBuffer();
            IntPtr errorInfoBuffer = errorInfoWrapper.GetBufferHandle();

            IntPtr dnnPointer = GetUnmanagedPointer();
            IntPtr charArrayPointer = GetOutputName(dnnPointer, index, errorInfoBuffer);

            if (charArrayPointer == IntPtr.Zero)
            {
                CDnnErrorInfo errorInfo = Marshal.PtrToStructure<CDnnErrorInfo>(errorInfoBuffer);
                throw new DnnException(errorInfo.Type, errorInfo.Description);
            }

            return Marshal.PtrToStringAnsi(charArrayPointer);
        }
    }
}
