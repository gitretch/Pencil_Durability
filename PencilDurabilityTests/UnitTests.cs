using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilDurability;

namespace PencilDurabilityTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void WhenPencilCreatedDefaultLengthIsFive()
        {
            Pencil pencil = new Pencil();
            Assert.AreEqual(5, pencil.Length);             
        }

        [TestMethod]
        public void LengthAlwaysZeroOrPositive()
        {
            Pencil pencil = new Pencil(-1);
            Assert.AreEqual(0, pencil.Length);
        }

        [TestMethod]
        public void InitialPointDurabilityCannotBeLessThanOne()
        {
            Pencil pencil = new Pencil(5, -1);
            Assert.AreEqual(1, pencil.PointDurability);
        }

    }
}
