using System.Collections.Generic;

using NUnit.Framework;

namespace AVLTree.Tests
{
    public class AVLTests
    {
        private Avl<int> avl;

        [SetUp]
        public void SetUp()
        {
            this.avl = new Avl<int>();
        }

        [Test]
        public void TraverseInOrder_AfterSingleInsert()
        {
            // Arrange
            this.avl.Insert(1);

            // Act
            List<int> nodes = new List<int>();
            this.avl.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void TraverseInOrder_AfterMultipleInserts()
        {
            // Arrange
            this.avl.Insert(2);
            this.avl.Insert(1);
            this.avl.Insert(3);

            // Act
            List<int> nodes = new List<int>();
            this.avl.Traverse(nodes.Add);

            // Assert
            int[] expectedNodes = { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Height_RootRight()
        {
            // Arrange
            this.avl.Insert(1);
            this.avl.Insert(2);

            // Assert
            Assert.AreEqual(2, this.avl.Root.Height);
            Assert.AreEqual(1, this.avl.Root.Right.Height);
        }

        [Test]
        public void Height_RootLeft()
        {
            // Arrange
            this.avl.Insert(2);
            this.avl.Insert(1);

            // Assert
            Assert.AreEqual(2, this.avl.Root.Height);
            Assert.AreEqual(1, this.avl.Root.Left.Height);
        }

        [Test]
        public void Height_RootLeftRight()
        {
            // Arrange
            this.avl.Insert(2);
            this.avl.Insert(1);
            this.avl.Insert(3);

            // Assert
            Assert.AreEqual(2, this.avl.Root.Height);
            Assert.AreEqual(1, this.avl.Root.Left.Height);
            Assert.AreEqual(1, this.avl.Root.Right.Height);
        }

        [Test]
        public void Rebalance_RootShouldHaveHeightTwo()
        {
            // Arrange
            this.avl.Insert(1);
            this.avl.Insert(2);
            this.avl.Insert(3);

            // Assert
            Assert.AreEqual(2, this.avl.Root.Height);
        }

        [Test]
        public void Rebalance_TestHeightOneNodes()
        {
            // Arrange
            for (int i = 1; i < 10; i++)
            {
                this.avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(1, this.avl.Root.Left.Left.Height); // 1
            Assert.AreEqual(1, this.avl.Root.Left.Right.Height); // 3
            Assert.AreEqual(1, this.avl.Root.Right.Left.Height); // 5
            Assert.AreEqual(1, this.avl.Root.Right.Right.Left.Height); // 7
            Assert.AreEqual(1, this.avl.Root.Right.Right.Right.Height); // 9
        }

        [Test]
        public void Rebalance_TestHeightTwoNodes()
        {
            // Arrange
            for (int i = 1; i < 10; i++)
            {
                this.avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(2, this.avl.Root.Left.Height); // 2
            Assert.AreEqual(2, this.avl.Root.Right.Right.Height); // 8
        }

        [Test]
        public void Rebalance_TestHeightThreeNodes()
        {
            // Arrange
            for (int i = 1; i < 10; i++)
            {
                this.avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(3, this.avl.Root.Right.Height); // 6
        }

        [Test]
        public void Rebalance_TestHeightFourNodes()
        {
            // Arrange
            for (int i = 1; i < 10; i++)
            {
                this.avl.Insert(i);
            }

            // Assert
            Assert.AreEqual(4, this.avl.Root.Height); // 4
        }

        [Test]
        public void Rebalance_SingleRight()
        {
            // Act
            this.avl.Insert(3);
            this.avl.Insert(2);
            this.avl.Insert(1);

            // Assert
            Assert.AreEqual(2, this.avl.Root.Value);
        }

        [Test]
        public void Rebalance_SingleLeft()
        {
            // Act
            this.avl.Insert(1);
            this.avl.Insert(2);
            this.avl.Insert(3);

            // Assert
            Assert.AreEqual(2, this.avl.Root.Value);
        }

        [Test]
        public void Rebalance_DoubleRight()
        {
            // Act
            this.avl.Insert(5);
            this.avl.Insert(2);
            this.avl.Insert(4);

            // Assert
            Assert.AreEqual(4, this.avl.Root.Value);
            Assert.AreEqual(2, this.avl.Root.Height);
            Assert.AreEqual(1, this.avl.Root.Left.Height);
            Assert.AreEqual(1, this.avl.Root.Right.Height);
        }

        [Test]
        public void Rebalance_DoubleLeft()
        {
            // Act
            this.avl.Insert(5);
            this.avl.Insert(7);
            this.avl.Insert(6);

            // Assert
            Assert.AreEqual(6, this.avl.Root.Value);
            Assert.AreEqual(2, this.avl.Root.Height);
            Assert.AreEqual(1, this.avl.Root.Left.Height);
            Assert.AreEqual(1, this.avl.Root.Right.Height);
        }
    }
}
