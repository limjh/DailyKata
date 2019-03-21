using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Game_클래스를_생성()
        {
            var game = new Game();
        }

        [TestMethod]
        public void int_를_인자로_하는_roll_함수를_호출()
        {
            var game = new Game();

            game.roll(1);
        }

        [TestMethod]
        public void int_를_return_하는_score_함수를_호출()
        {
            var game = new Game();

            Assert.AreEqual(0, game.score());
        }

        [TestMethod]
        public void 모두_1개의_핀을_쓰러뜨리는_20번의_roll을_수행시_20점을_획득한다()
        {
            var game = new Game();

            for(int i = 0; i < 20; i++)
            {
                game.roll(1);
            }

            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void spare처리하기()
        {
            var game = new Game();

            game.roll(1);
            game.roll(9);

            game.roll(1);
            Assert.AreEqual(12, game.score());
        }
    }
}
