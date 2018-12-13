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

        [TestMethod]
        public void InitialEraserDurabilityCannotBeLessThanZero()
        {
            Pencil pencil = new Pencil(5, 20, -1);
            Assert.AreEqual(0, pencil.EraserDurability);
        }


        [TestMethod]
        public void WhenLengthIs5AndSharpenCalledLengthIsReducedBy1()
        {
            Pencil pencil = new Pencil(5);
            pencil.Sharpen();
            Assert.AreEqual(4, pencil.Length);
        }


        [TestMethod]
        public void WhenSharpenCalledCurrentPointDurabilityIsResetToInitialPointDurability()
        {
            Pencil pencil = new Pencil(5, 20);
            pencil.Sharpen();
            Assert.AreEqual(20, pencil.PointDurability);
        }

        [TestMethod]
        public void WhenSharpenCalledIfLengthIs0PointDurabilityWontBeReset()
        {
            Pencil pencil = new Pencil(0, 19);
            pencil.Sharpen();
            Assert.AreEqual(19, pencil.PointDurability);
        }

        [TestMethod]
        public void WhenDegradePointCalledIfCurrentPointDurabilityIsGreaterThanZeroReturnsTrue()
        {
            Pencil pencil = new Pencil();
            char letter = ' ';
            Assert.AreEqual(true, pencil.DegradePoint(letter));
        }

        [TestMethod]
        public void WhenDegradePointPassedUpperCaseCharCurrentPointDurabilityDecreasesByTwo()
        {
            Pencil pencil = new Pencil();
            char letter = 'A';
            pencil.DegradePoint(letter);
            Assert.AreEqual(18, pencil.PointDurability);
        }

        [TestMethod]
        public void WhenWritePassedOneCharThatCharIsAppendedToPaper()
        {
            Pencil pencil = new Pencil();
            string newText = "a";
            pencil.Write(newText);
            Assert.AreEqual("a", pencil.Paper);
        }

        [TestMethod]
        public void WhenWritePassedAdditionalStringItAppendsToExistingText()
        {
            Pencil pencil = new Pencil();
            string existingText = "A cat meows.";
            pencil.Write(existingText);
            string appendText = " A dog barks.";
            pencil.Write(appendText);
            Assert.AreEqual("A cat meows. A dog barks.", pencil.Paper);
        }



    }
}
