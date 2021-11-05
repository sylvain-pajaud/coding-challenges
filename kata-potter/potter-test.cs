using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kata_potter
{
    [TestClass]
    public class PotterTest
    {
        private const decimal BOOK_PRICE = 8;
        private const decimal FIRST_DISCOUNT = 0.95M;
        private const decimal SECOND_DISCOUNT = 0.90M;
        private const decimal THIRD_DISCOUNT = 0.80M;
        private const decimal FOURTH_DISCOUNT = 0.75M;

        [TestMethod]
        public void NoBooks_TotalIsZero()
        {
            var total = PotterUtils.CheckOut(new int[] { });
            Assert.IsTrue(total == 0);
        }

        [TestMethod]
        public void FIrstBook_NoDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1 });
            Assert.IsTrue(total == BOOK_PRICE);
        }

        [TestMethod]
        public void SecondBook_NoDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 2 });
            Assert.IsTrue(total == BOOK_PRICE);
        }

        [TestMethod]
        public void ThirdBook_NoDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 3 });
            Assert.IsTrue(total == BOOK_PRICE);
        }

        [TestMethod]
        public void FourthBook_NoDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 4 });
            Assert.IsTrue(total == BOOK_PRICE);
        }

        [TestMethod]
        public void FithBook_NoDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 5 });
            Assert.IsTrue(total == BOOK_PRICE);
        }

        [TestMethod]
        public void TwoSameBooks_NoDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1, 1 });
            Assert.IsTrue(total == 2 * BOOK_PRICE);
        }

        [TestMethod]
        public void TwoDifferentBooks_Discout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1, 2 });
            Assert.IsTrue(total == 2 * BOOK_PRICE * FIRST_DISCOUNT);
        }

        [TestMethod]
        public void ThreeDifferentBooks_SecondDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1, 3, 4 });
            Assert.IsTrue(total == (3 * BOOK_PRICE * SECOND_DISCOUNT));
        }

        [TestMethod]
        public void ThreeBooksTwodifferents_FirstDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1, 2, 2 });
            Assert.IsTrue(total == ((2 * BOOK_PRICE * FIRST_DISCOUNT) + BOOK_PRICE));
        }

        [TestMethod]
        public void FourDifferentBooks_ThirdDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1, 2, 3, 4 });
            Assert.IsTrue(total == (4 * BOOK_PRICE * THIRD_DISCOUNT));
        }

        [TestMethod]
        public void FiveDifferentBooks_FourthDiscout()
        {
            var total = PotterUtils.CheckOut(new int[] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(total == (5 * BOOK_PRICE * FOURTH_DISCOUNT));
        }

        [TestMethod]
        public void testSeveralDiscounts()
        {
            Assert.AreEqual(8 + (8 * 2 * FIRST_DISCOUNT), PotterUtils.CheckOut(new int[] { 1, 1, 2 }));
            Assert.AreEqual(2 * (8 * 2 * FIRST_DISCOUNT), PotterUtils.CheckOut(new int[] { 1, 1, 2, 2 }));
            Assert.AreEqual((8 * 4 * THIRD_DISCOUNT) + (8 * 2 * FIRST_DISCOUNT), PotterUtils.CheckOut(new int[] { 1, 1, 2, 3, 3, 4 }));
            Assert.AreEqual(8 + (8 * 5 * FOURTH_DISCOUNT), PotterUtils.CheckOut(new int[] { 1, 2, 2, 3, 4, 5 }));
        }

        [TestMethod]
        public void TestEdgeCases()
        {
            Assert.AreEqual(2 * (8 * 4 * THIRD_DISCOUNT), PotterUtils.CheckOut(new int[] { 1, 1, 2, 2, 3, 3, 4, 5 }));
            Assert.AreEqual(
                3 * (8 * 5 * FOURTH_DISCOUNT) + 2 * (8 * 4 * THIRD_DISCOUNT),
                PotterUtils.CheckOut(new int[]
                    { 1, 1, 1, 1, 1,
                    2, 2, 2, 2, 2,
                    3, 3, 3, 3,
                    4, 4, 4, 4, 4,
                    5, 5, 5, 5}));
        }

        [TestMethod]
        public void TestEdgeCases2()
        {
            Assert.AreEqual(78.8M, PotterUtils.CheckOut(new int[] { 1, 1, 1, 2, 2, 3, 3, 3, 3, 4, 4, 5 }));
        }

        [TestMethod]
        public void TestEdgeCases3()
        {
            Assert.AreEqual(100M, PotterUtils.CheckOut(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 }));
            Assert.AreEqual(200M, PotterUtils.CheckOut(new int[] { 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }));
        }
    }
}