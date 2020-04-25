using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestImage
{
    public class OperationTimer: IDisposable
    {
        private Stopwatch m_sw;
        private readonly string m_text;

        public OperationTimer(string text)
        {
            m_text = text;
            PrepareForOperation();
            m_sw = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0}\nElapsed: {1}", m_text, m_sw.Elapsed);
            m_sw.Stop();
            m_sw = null;
        }
        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
