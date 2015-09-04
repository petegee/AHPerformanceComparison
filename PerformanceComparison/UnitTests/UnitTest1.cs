using System;
using System.Diagnostics;
using System.Drawing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PerformanceComparison;

namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ColourSequenceTest
    {
        public ColourSequenceTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Initialize() is called once during test execution before
        /// test methods in this test class are executed.
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            //  TODO: Add test initialization code
        }

        /// <summary>
        /// Cleanup() is called once during test execution after
        /// test methods in this class have executed unless the
        /// corresponding Initialize() call threw an exception.
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            //  TODO: Add test cleanup code
        }

        [TestMethod]
        public void DumpValues()
        {
            ColourSequence seq = new ColourSequence();

            seq.Reset();

            for (int i = 0; i < 100; i++)
            {
                System.Drawing.Color colo = seq.Current;                

                Console.WriteLine("{0} {1} {2}", colo.R, colo.G, colo.B);

                seq.Increment();
            }

            seq.Reset();
        }
    }
}
