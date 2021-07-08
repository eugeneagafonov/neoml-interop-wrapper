using System;
using System.Runtime.InteropServices;

namespace NeoMLInteropWrapper
{
    public abstract class UnmanagedResourceHandle : SafeHandle
    {
        internal UnmanagedResourceHandle(IntPtr p) : base(IntPtr.Zero, true)
        {
            SetHandle(p);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            if (!IsInvalid)
            {
                DeleteHandle();
                handle = IntPtr.Zero;
            }
            return true;
        }

        internal IntPtr GetUnmanagedPointer()
        {
            return handle;
        }

        internal abstract void DeleteHandle();
    }
}
