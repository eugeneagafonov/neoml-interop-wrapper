using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NeoMLInteropWrapper
{
    /// <summary>
    /// A wrapper for exposing a GC pinned pointer to a managed array
    /// </summary>
    /// <typeparam name="T">This wrapper is intended to be used with arrays of primitive types: byte, int, float, etc.</typeparam>
    internal class PinnedBuffer<T> : SafeHandle where T : struct
    {
        private T[] _data;
        private GCHandle _gcHandle;

        internal PinnedBuffer(T[] bytes) : base(IntPtr.Zero, true)
        {
            _data = bytes;
            _gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        }

        protected override bool ReleaseHandle()
        {
            _gcHandle.Free();
            return true;
        }

        internal T[] Data => _data;

        internal IntPtr PinnedPointer => _gcHandle.AddrOfPinnedObject();

        public override bool IsInvalid => !_gcHandle.IsAllocated;
    }
}
