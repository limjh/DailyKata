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
        public void roll_score_함수_생성()
        {
            var game = new Game();

            game.roll(1);

            Assert.AreEqual(1, game.score());
        }

        [TestMethod]
        public void _4_ball_no_spare_no_strike()
        {
            var game = new Game();

            game.roll(1);
            game.roll(2);
            game.roll(3);
            game.roll(4);

            Assert.AreEqual(10, game.score());
        }

        [TestMethod]
        public void _3_ball_1_spare()
        {
            var game = new Game();

            game.roll(1);
            game.roll(9);
            game.roll(1);

            Assert.AreEqual(12, game.score());
        }

        [TestMethod]
        public void _21_ball_all_5_pin()
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
        public void _4_ball_1_strike()
        {
            var game = new Game();

            game.roll(10);

            game.roll(1);
            game.roll(2);

            game.roll(3);

            Assert.AreEqual(19, game.score());
        }

        [TestMethod]
        public void _4_ball_2_strike()
        {
            var game = new Game();

            game.roll(10);//22

            game.roll(10);//15

            game.roll(2); //5
            game.roll(3);

            Assert.AreEqual(42, game.score());
        }

        [TestMethod]
        public void _4_ball_1_strike_1_gutter()
        {
            var game = new Game();

            game.roll(10);//15

            game.roll(0);//5
            game.roll(5);

            game.roll(5);//5

            Assert.AreEqual(25, game.score());
        }


        [TestMethod]
        public void all_strike()
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
    }
}
