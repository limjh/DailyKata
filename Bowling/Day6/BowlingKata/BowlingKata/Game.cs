using System;

namespace BowlingKata
{
    public class Game
    {
        private int ballCnt;
        private HalfFrame[] frames;

        public Game()
        {
            frames = new HalfFrame[21];
            ballCnt = 0;
        }

        public void roll(int pin)
        {
            frames[ballCnt].pin = pin;

            if (ballCnt % 2 == 1 && pin + frames[ballCnt - 1].pin == 10)
            {
                frames[ballCnt].isSpared = true;
            }
            else if (ballCnt % 2 == 0 && pin == 10)
            {
                frames[ballCnt].isStriked = true;

                if (ballCnt < 18)
                    ballCnt++;
            }
            else if (pin == 0)
            {
                frames[ballCnt].isGutter = true;
            }


            ballCnt++;
        }

        public int score()
        {
            int totalScore = 0;

            for(int i = 0; i < frames.Length; i++)
            {

                if (frames[i].isSpared && i < 18)
                {
                    frames[i].pin += frames[i + 1].pin;
                }
                else if (frames[i].isStriked && i < 18)
                {
                    int addCnt = 2;
                    for(int j = i + 2; j < frames.Length; j++)
                    {
                        if (addCnt > 0 && (frames[j].pin != 0 || frames[j].isGutter))
                        {
                            frames[i].pin += frames[j].pin;
                            addCnt--;
                        }
                    }

                }

                totalScore += frames[i].pin;
            }

            return totalScore;
        }
    }

    public struct HalfFrame
    {
        public int pin;
        public bool isSpared;
        public bool isStriked;
        public bool isGutter;
    }
}