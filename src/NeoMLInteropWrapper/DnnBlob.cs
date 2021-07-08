using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NeoMLInteropWrapper
{
    public partial class DnnBlob : UnmanagedResourceHandle
    {
        private CDnnBlobDesc _blobDesc;

        public DnnBlob(IntPtr unmanagedDnnBlob) : base(unmanagedDnnBlob)
        {
            _blobDesc = Marshal.PtrToStructure<CDnnBlobDesc>(handle);
        }

        public TDnnBlobType BlobType => _blobDesc.Type;

        public int BatchLength => _blobDesc.BatchLength;

        public int BatchWidth => _blobDesc.BatchWidth;

        public int Height => _blobDesc.Height;

        public int Width => _blobDesc.Width;

        public int Depth => _blobDesc.Depth;

        public int ChannelCount => _blobDesc.ChannelCount;

        public int DataSizeInBytes => _blobDesc.DataSize;        

        internal override void DeleteHandle()
        {
            DestroyDnnBlob(handle);
        }
    }
}
