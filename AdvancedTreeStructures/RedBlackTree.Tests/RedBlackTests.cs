using System.Collections.Generic;

using NUnit.Framework;

namespace RedBlackTree.Tests
{
    [TestFixture]
    public class RedBlackTests
    {
        private RedBlackTree<int> rbt;

        [SetUp]
        public void SetUp()
        {
            this.rbt = new RedBlackTree<int>();
        }

        [Test]
        public void Insert_Single_TraverseInOrder()
        {
            // Arrange
            this.rbt.Insert(1);

            // Act
            List<int> nodes = new List<int>();
            this.rbt.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Insert_Multiple_TraverseInOrder()
        {
            // Arrange
            this.rbt.Insert(2);
            this.rbt.Insert(1);
            this.rbt.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            this.rbt.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void TraverseInOrder_AfterSingleInsert()
        {
            // Arrange
            this.rbt.Insert(1);

            // Act
            List<int> nodes = new List<int>();
            this.rbt.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void TraverseInOrder_AfterMultipleInserts()
        {
            // Arrange
            this.rbt.Insert(2);
            this.rbt.Insert(1);
            this.rbt.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            this.rbt.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}
