namespace UnitTests
{
    using System;

    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListUnitTest
    {
        private DynamicList<decimal> dynamicList;

        private decimal[] testDecimals;

        [TestInitialize]
        public void InitializeDynamicList()
        {
            this.dynamicList = new DynamicList<decimal>();
            this.testDecimals = new[] { 27M, 29M, 31M };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Empty list not throwing out of range exception.")]
        public void Indexer_EmptyList_ThrowsException()
        {
            var temp = this.dynamicList[0];
        }

        [TestMethod]
        public void Add_DecimalNumber_NumberAdded()
        {
            this.dynamicList.Add(this.testDecimals[2]);

            Assert.AreEqual(
                this.testDecimals[2],
                this.dynamicList[0], 
                "The element at [0] position is incorrect.");
        }

        [TestMethod]
        public void Contains_DecimalNumber_NumberIsContained()
        {
            this.dynamicList.Add(this.testDecimals[2]);

            Assert.AreEqual(
                true,
                this.dynamicList.Contains(this.testDecimals[2]),
                "The list should contain the added number.");
        }

        [TestMethod]
        public void Contains_DecimalNumber_NumberIsNotContained()
        {
            Assert.AreEqual(
                false,
                this.dynamicList.Contains(this.testDecimals[2]),
                "The list should not contain the number.");
        }

        [TestMethod]
        public void IndexOf_TwoDecimalNumbers_IndexOfNumberIsNotFound()
        {
            this.dynamicList.Add(this.testDecimals[2]);
            this.dynamicList.Add(this.testDecimals[0]);

            Assert.AreEqual(
                -1,
                this.dynamicList.IndexOf(this.testDecimals[1]),
                "IndexOf() should return -1 index if element is not present.");
        }

        [TestMethod]
        public void IndexOf_TwoDecimalNumbers_IndexOfNumberIsFound()
        {
            this.dynamicList.Add(this.testDecimals[0]);
            this.dynamicList.Add(this.testDecimals[1]);

            Assert.AreEqual(
                1,
                this.dynamicList.IndexOf(this.testDecimals[1]),
                "IndexOf() does not return the proper index of the element");
        }

        [TestMethod]
        public void Remove_ThreeDecimalNumbers_NumberIsRemoved()
        {
            this.dynamicList.Add(this.testDecimals[2]);
            this.dynamicList.Add(this.testDecimals[1]);
            this.dynamicList.Add(this.testDecimals[0]);

            this.dynamicList.Remove(this.testDecimals[1]);
            Assert.AreEqual(
                false,
                this.dynamicList.Contains(29M),
                "The number is not removed from the list.");
        }

        [TestMethod]
        public void Remove_TwoDecimalNumbers_NumberIsNotRemoved()
        {
            this.dynamicList.Add(this.testDecimals[0]);
            this.dynamicList.Add(this.testDecimals[1]);

            this.dynamicList.Remove(this.testDecimals[1]);
            Assert.AreEqual(
                true,
                this.dynamicList.Contains(this.testDecimals[0]),
                "The number should not be removed from the list.");
        }
    }
}
