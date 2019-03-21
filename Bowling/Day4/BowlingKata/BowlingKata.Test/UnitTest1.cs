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

            int pin = 1;
            game.roll(pin);

            Assert.AreEqual(pin, game.score());
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
        public void strike처리시_다음프레임의_두_ball_의_점수가_보너스로_계산됨()
        {
            var game = new Game();

            game.roll(10);
            game.roll(2);
            game.roll(3);

            Assert.AreEqual(20, game.score());
        }
    }
}
