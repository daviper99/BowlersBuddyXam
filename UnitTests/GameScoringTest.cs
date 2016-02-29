using BowlersBuddyXam.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlersBuddyXam.Tests
{
    public class GameScoreTest
    {
        [TestClass]
        public class TestGame
        {
            private GameScore g;

            [TestInitialize]
            public void setUp()
            {
                g = new GameScore();
            }

            [TestMethod]
            public void testTwoThrowsNoMark()
            {
                g.Add(5);
                g.Add(4);
                Assert.AreEqual(9, g.Score());
            }

            [TestMethod]
            public void testFourThrowsNoMark()
            {
                g.Add(5);
                g.Add(4);
                g.Add(7);
                g.Add(2);
                Assert.AreEqual(18, g.Score());
                Assert.AreEqual(9, g.ScoreForFrame(1));
                Assert.AreEqual(18, g.ScoreForFrame(2));
            }

            [TestMethod]
            public void testSimpleSpare()
            {
                g.Add(3);
                g.Add(7);
                g.Add(3);
                Assert.AreEqual(13, g.ScoreForFrame(1));
            }

            [TestMethod]
            public void testSimpleFrameAfterSpare()
            {
                g.Add(3);
                g.Add(7);
                g.Add(3);
                g.Add(2);
                Assert.AreEqual(13, g.ScoreForFrame(1));
                Assert.AreEqual(18, g.ScoreForFrame(2));
                Assert.AreEqual(18, g.Score());
            }

            [TestMethod]
            public void testSimpleStrike()
            {
                g.Add(10);
                g.Add(3);
                g.Add(6);
                Assert.AreEqual(19, g.ScoreForFrame(1));
                Assert.AreEqual(28, g.Score());
            }

            [TestMethod]
            public void testPerfectGame()
            {
                for (var i = 0; i < 12; i++)
                {
                    g.Add(10);
                }
                Assert.AreEqual(300, g.Score());
            }

            [TestMethod]
            public void testEndOfArray()
            {
                for (var i = 0; i < 9; i++)
                {
                    g.Add(0);
                    g.Add(0);
                }
                g.Add(2);
                g.Add(8); // 10th frame spare
                g.Add(10); // Strike in last position of array.
                Assert.AreEqual(20, g.Score());
            }

            [TestMethod]
            public void testSampleGame()
            {
                g.Add(1);
                g.Add(4);
                g.Add(4);
                g.Add(5);
                g.Add(6);
                g.Add(4);
                g.Add(5);
                g.Add(5);
                g.Add(10);
                g.Add(0);
                g.Add(1);
                g.Add(7);
                g.Add(3);
                g.Add(6);
                g.Add(4);
                g.Add(10);
                g.Add(2);
                g.Add(8);
                g.Add(6);
                Assert.AreEqual(133, g.Score());
            }

            [TestMethod]
            public void testHeartBreak()
            {
                for (var i = 0; i < 11; i++)
                    g.Add(10);
                g.Add(9);
                Assert.AreEqual(299, g.Score());
            }

            [TestMethod]
            public void testTenthFrameSpare()
            {
                for (var i = 0; i < 9; i++)
                    g.Add(10);
                g.Add(9);
                g.Add(1);
                g.Add(1);
                Assert.AreEqual(270, g.Score());
            }

            // Tests for split determination code
            /// <summary>
            /// </summary>
            [TestMethod]
            public void testSplitTwoPin()
            {
                Assert.AreEqual(true, g.IsSplit(new[] {7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {8, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {7, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {7, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 6}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 5}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 6}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {8, 9}));
            }

            [TestMethod]
            public void testSplitThreePin()
            {
                Assert.AreEqual(true, g.IsSplit(new[] {2, 5, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 7, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 7, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 4, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 4, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 4, 6}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 8, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 6, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 6, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 4}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 6}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 6}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 5, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 5, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 6, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 7, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 7, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 8, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 8, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 5, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 5, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 5, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 7, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 6, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 6, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {5, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 7, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 7, 9}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {6, 8, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {7, 9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {7, 8, 10}));
            }

            [TestMethod]
            public void testSplitFourPin()
            {
                Assert.AreEqual(true, g.IsSplit(new[] {2, 4, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 4, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 6, 7}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 5, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 7, 8}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 5, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 6, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 5, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 7, 8, 10}));
            }

            [TestMethod]
            public void testSplitFivePin()
            {
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 7, 8, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {4, 6, 7, 9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 6, 7, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 4, 6, 7, 10}));
            }

            [TestMethod]
            public void testSplitSixPin()
            {
                Assert.AreEqual(true, g.IsSplit(new[] {2, 4, 6, 7, 8, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {3, 4, 6, 7, 9, 10}));
                Assert.AreEqual(true, g.IsSplit(new[] {2, 3, 4, 6, 7, 10}));
            }

            [TestMethod]
            public void testSplitHeadPin()
            {
                Assert.AreEqual(false, g.IsSplit(new[] {1, 2, 4, 7, 10}));
            }

            [TestMethod]
            public void testSplitNinePin()
            {
                Assert.AreEqual(false, g.IsSplit(new[] {10}));
            }

            [TestMethod]
            public void testSplitNoSplit()
            {
                Assert.AreEqual(false, g.IsSplit(new[] {6, 9, 10}));
                Assert.AreEqual(false, g.IsSplit(new[] {2, 8}));
                Assert.AreEqual(false, g.IsSplit(new[] {2, 4, 5, 8}));
                Assert.AreEqual(false, g.IsSplit(new[] {3, 6, 10}));
                Assert.AreEqual(false, g.IsSplit(new[] {4, 7}));
                Assert.AreEqual(false, g.IsSplit(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}));
                Assert.AreEqual(false, g.IsSplit(new[] { 10 }));
            }

            [TestMethod]
            public void testSplitNull()
            {
                Assert.AreEqual(false, g.IsSplit(null));
            }
        }
    }
}