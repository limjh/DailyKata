using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Game_클래스_생성()
        {
            var game = new Game();
        }

        [TestMethod]
        public void roll_함수_생성()
        {
            var game = new Game();

            int pin = 1;

            game.roll(pin);
        }

        [TestMethod]
        public void score_함수_생성()
        {
            var game = new Game();

            int pin = 1;

            game.roll(pin);

            Assert.AreEqual(pin, game.score());
        }

        [TestMethod]
        public void _2_ball_no_spare()
        {
            var game = new Game();

            game.roll(2);
            game.roll(5);

            Assert.AreEqual(7, game.score());
        }

        [TestMethod]
        public void _3_ball_1_spare()
        {
            var game = new Game();

            game.roll(5);
            game.roll(5);
            game.roll(5);

            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void _5_ball_2_spare()
        {
            var game = new Game();

            game.roll(5);
            game.roll(5);
            game.roll(5);
            game.roll(5);
            game.roll(5);

            Assert.AreEqual(35, game.score());
        }

        [TestMethod]
        public void _21_ball_all_spare()
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

        [TestMethod]
        public void _3_ball_1_strike()
        {
            var game = new Game();

            game.roll(10);
            game.roll(5);
            game.roll(5);

            Assert.AreEqual(30, game.score());
        }

        [TestMethod]
        public void _4_ball_1_strike_1_gutter()
        {
            var game = new Game();

            game.roll(10);
            game.roll(0);
            game.roll(5);
            game.roll(5);

            Assert.AreEqual(25, game.score());
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
