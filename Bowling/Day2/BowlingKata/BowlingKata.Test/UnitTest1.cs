using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Game_클래스_인스턴스생성()
        {
            var game = new Game();
        }

        [TestMethod]
        public void int_를_인자로하는_roll_함수_호출()
        {
            var game = new Game();

            game.roll(1);
        }

        [TestMethod]
        public void int_를_리턴하는_score_함수_호출()
        {
            var game = new Game();

            int result = game.score();
        }

        [TestMethod]
        public void roll호출시_입력된_pin값이_누적되어_score_함수로_확인가능()
        {
            var game = new Game();

            for (int i = 0; i < 20; i++)
                game.roll(1);

            Assert.AreEqual(20, game.score());
        }

        [TestMethod]
        public void spare처리시_다음프레임의_첫_ball_의_점수가_보너스로_계산됨()
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
