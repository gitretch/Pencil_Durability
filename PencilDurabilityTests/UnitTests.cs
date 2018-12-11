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

    }
}
