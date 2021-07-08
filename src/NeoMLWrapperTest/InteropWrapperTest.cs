using System;

using NeoMLInteropWrapper;

namespace NeoMLWrapperTest
{
    public class InteropWrapperTest
    {
        public static void RunTestWithConsoleOutput(byte[] dnnInput, byte[] input, float[] expectedOutput)
        {
            using var engine = NeoML.CreateCPUMathEngineInstance();
            using var blob = engine.CreateBlob(type: TDnnBlobType.DBT_Float, batchLength: 1, batchWidth: 1, height: 32, width: 32, depth: 1, channelCount: 3);
            using var dnn = engine.CreateDnnFromBuffer(dnnInput);

            // load test data
            blob.SetData(input);
            dnn.SetInputBlob(index: 0, blob);

            // run the dnn
            dnn.RunOnce();

            // get results and compare it to the reference data set
            using var outputBlob = dnn.GetOutputBlob(index: 0);

            float[] result = outputBlob.GetFloatData();

            Console.WriteLine($"|    Result    |   Expected   |       Delta      |");
            Console.WriteLine($"|--------------|--------------|------------------|");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"| {result[i],-12} | {expectedOutput[i],-12} | {result[i] - expectedOutput[i],-16} |");
            }
        }
    }
}
