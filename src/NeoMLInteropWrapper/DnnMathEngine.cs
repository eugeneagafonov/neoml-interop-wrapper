using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NeoMLInteropWrapper
{
    public partial class DnnMathEngine : UnmanagedResourceHandle
    {
        private TDnnMathEngineType _type;

        internal DnnMathEngine(IntPtr unmanagedDnnMathEngine) : base(unmanagedDnnMathEngine)
        {
            _type = Marshal.PtrToStructure<CDnnMathEngineDesc>(handle).Type;
        }

        internal override void DeleteHandle()
        {
            DestroyMathEngine(handle);
        }

        public TDnnMathEngineType EngineType
        {
            get { return _type; }
        }
    }
}
