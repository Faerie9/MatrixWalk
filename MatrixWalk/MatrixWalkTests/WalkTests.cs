using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixWalk;

namespace MatrixWalkTests
{
    [TestClass]
    public class WalkTests
    {
        [TestMethod]
        public void MakeNormalWalk()
        {
            Matrix testMatrix = new Matrix(5);
            Walk testWalk = new Walk(testMatrix);

            Assert.AreEqual(testWalk.Field, testMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MakeWalkNullMatrix()
        {
            Walk testWalk = new Walk(null);
        }
    }
}
