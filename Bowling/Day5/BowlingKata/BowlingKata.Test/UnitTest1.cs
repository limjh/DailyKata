using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void game_클래스_생성()
        {
            var game = new Game();
        }

        [TestMethod]
        public void roll_score_함수_호출()
        {
            var game = new Game();

            game.roll(1);

            Assert.AreEqual(1, game.score());
        }

        [TestMethod]
        public void _2ball_no_spare_no_strike()
        {
            var game = new Game();

            game.roll(1);
            game.roll(8);

            Assert.AreEqual(9, game.score());
        }


        [TestMethod]
        public void _3ball_1spare()
        {
            var game = new Game();

            game.roll(1);
            game.roll(9);
            game.roll(1);

            Assert.AreEqual(12, game.score());
        }

        [TestMethod]
        public void 연속_spare_처리_2회()
        {
            var game = new Game();

            game.roll(1);
            game.roll(9); //11
            game.roll(1);
            game.roll(9); //19
            game.roll(9); //9

            Assert.AreEqual(39, game.score());
        }

        [TestMethod]
        public void _3ball_1strike()
        {
            var game = new Game();

            game.roll(10);
            game.roll(1);
            game.roll(1);

            Assert.AreEqual(14, game.score());
        }

        [TestMethod]
        public void _4ball_1strike_1gutter()
        {
            var game = new Game();

            game.roll(10);
            game.roll(1);
            game.roll(0);
            game.roll(1);

            Assert.AreEqual(13, game.score());
        }

        [TestMethod]
        public void random_test_01()
        {
            var game = new Game();

            game.roll(5);
            game.roll(2);

            Assert.AreEqual(7, game.score());
        }

        [TestMethod]
        public void random_test_02()
        {
            var game = new Game();

            game.roll(5);
            game.roll(2);
            game.roll(9);
            game.roll(1);
            game.roll(3);
            game.roll(2);

            Assert.AreEqual(25, game.score());
        }

        [TestMethod]
        public void random_test_03()
        {
            var game = new Game();

            game.roll(5);
            game.roll(2);
            game.roll(9);
            game.roll(1);
            game.roll(3);
            game.roll(2);
            game.roll(10);

            Assert.AreEqual(35, game.score());
        }

        [TestMethod]
        public void random_test_04()
        {
            var game = new Game();

            game.roll(5);
            game.roll(2);
            game.roll(9);
            game.roll(1);
            game.roll(3);
            game.roll(2);
            game.roll(10);
            game.roll(5);
            game.roll(0);

            Assert.AreEqual(45, game.score());
        }

        [TestMethod]
        public void random_test_05()
        {
            var game = new Game();

            game.roll(5);
            game.roll(2);

            game.roll(9);
            game.roll(1);

            game.roll(3);
            game.roll(2);

            game.roll(10);

            game.roll(5);
            game.roll(0);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(8);
            game.roll(1);

            Assert.AreEqual(131, game.score());
        }

        [TestMethod]
        public void random_test_06()
        {
            var game = new Game();

            game.roll(5);
            game.roll(2);

            game.roll(9);
            game.roll(1);

            game.roll(3);
            game.roll(2);

            game.roll(10);

            game.roll(5);
            game.roll(0);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(8);
            game.roll(1);

            game.roll(5);
            game.roll(5);
            game.roll(4);

            Assert.AreEqual(145, game.score());
        }

        [TestMethod]
        public void random_test_07()
        {
            var game = new Game();

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);

            game.roll(10);
            game.roll(10);
            game.roll(10);

            Assert.AreEqual(300, game.score());
        }

        [TestMethod]
        public void random_test_08()
        {
            var game = new Game();

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);

            game.roll(5);
            game.roll(5);
            game.roll(5);

            Assert.AreEqual(150, game.score());
        }
    }
}
