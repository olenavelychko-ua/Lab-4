using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace TestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Eventloop()
        {
            Event_loop_Test test = new Event_loop_Test();
            test.names = new string[] { "Foo", "Foo2", "exit" };
            test.indexRead = 0;
            test.indexWrite = 0;

            test.Threadmain();

            Assert.AreEqual(test.indexWrite, 3);
            Assert.AreEqual(test.indexRead, 3);
        }
    }

    public class Event_loop_Test : Event_loop
    {
        public string[] names;
        public int indexRead = 0;
        public int indexWrite = 0;

        override public string ReadLine()
        {
            Thread.Sleep(100);
            return names[indexRead++];
        }

        override public void WriteLine(string strline)
        {
            indexWrite++;
        }
    }

}
