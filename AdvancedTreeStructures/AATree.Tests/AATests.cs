using System.Collections.Generic;

using NUnit.Framework;

namespace AATree.Tests
{
    public class AATests
    {
        private AaTree<int> aaTree;
        private readonly int[] input = 
        {
            18, 13, 1, 7, 42, 73, 56, 24, 6, 2, 74, 69, 55
        };

        [SetUp]
        public void Setup()
        {
            this.aaTree = new AaTree<int>();

            foreach (int integer in this.input) 
            {
                this.aaTree.Insert(integer);
            }
        }

        [Test]
        public void Insert_Levels()
        {
            AaTree<int> aaTree = new AaTree<int>();

            aaTree.Insert(338);
            aaTree.Insert(141);
            aaTree.Insert(650);
            aaTree.Insert(26);
            aaTree.Insert(222);
            aaTree.Insert(490);
            aaTree.Insert(700);
            aaTree.Insert(822);
            aaTree.Insert(154);
            aaTree.Insert(284);
            aaTree.Insert(593);
            aaTree.Insert(795);
            aaTree.Insert(854);
            aaTree.Insert(969);
            
            Assert.AreEqual(3, aaTree.Root.Level);

            Assert.AreEqual(2, aaTree.Root.Left.Level);
            Assert.AreEqual(2, aaTree.Root.Left.Right.Level);
            Assert.AreEqual(2, aaTree.Root.Right.Left.Level);
            Assert.AreEqual(2, aaTree.Root.Right.Right.Level);

            Assert.AreEqual(1, aaTree.Root.Left.Left.Level);
            Assert.AreEqual(1, aaTree.Root.Left.Right.Left.Level);
            Assert.AreEqual(1, aaTree.Root.Left.Right.Right.Level);
            Assert.AreEqual(1, aaTree.Root.Right.Left.Left.Right.Level);
            Assert.AreEqual(1, aaTree.Root.Right.Left.Right.Level);
            Assert.AreEqual(1, aaTree.Root.Right.Right.Left.Level);
            Assert.AreEqual(1, aaTree.Root.Right.Right.Right.Level);
        }

        [Test]
        public void Insert_Levels_Two()
        {
            Assert.AreEqual(3, this.aaTree.Root.Level);
            Assert.AreEqual(3, this.aaTree.Root.Right.Level);

            Assert.AreEqual(2, this.aaTree.Root.Left.Level);
            Assert.AreEqual(2, this.aaTree.Root.Right.Left.Level);
            Assert.AreEqual(2, this.aaTree.Root.Right.Right.Level);

            Assert.AreEqual(1, this.aaTree.Root.Left.Left.Level);
            Assert.AreEqual(1, this.aaTree.Root.Left.Right.Level);
            Assert.AreEqual(1, this.aaTree.Root.Left.Left.Right.Level);
            Assert.AreEqual(1, this.aaTree.Root.Right.Right.Right.Level);
            Assert.AreEqual(1, this.aaTree.Root.Right.Right.Left.Level);
            Assert.AreEqual(1, this.aaTree.Root.Right.Left.Left.Right.Level);
            Assert.AreEqual(1, this.aaTree.Root.Right.Left.Right.Level);
            Assert.AreEqual(1, this.aaTree.Root.Right.Left.Left.Level);
        }

        [Test]
        public void TraverseInOrder_AfterSingleInsert()
        {
            List<int> numbers = new List<int>();
            this.aaTree.Traverse(n => numbers.Add(n));
            List<int> expected = new List<int> { 1, 2, 6, 7, 13, 18, 24, 42, 55, 56, 69, 73, 74 };

            Assert.AreEqual(expected.Count, numbers.Count);
            CollectionAssert.AreEqual(expected, numbers);
        }

        [Test]
        public void TraverseInOrder_AfterMultipleInserts()
        {
            // Arrange
            AaTree<int> aaTree = new AaTree<int>();
            aaTree.Insert(2);
            aaTree.Insert(1);
            aaTree.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            aaTree.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}
