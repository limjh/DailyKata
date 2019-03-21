using System;

namespace BowlingKata
{
    public class Game
    {
        public int currentScore;
        public int rollCnt;
        public int prvPin;
        public bool isSpared;

        public Game()
        {
            currentScore = 0;
            rollCnt = 0;
            isSpared = false;
        }

        public void roll(int pin)
        {
            rollCnt++;

            if (rollCnt % 2 == 0 && (pin + prvPin == 10))
                isSpared = true;

            if (rollCnt % 2 == 1 && isSpared)
            { 
                currentScore += pin + pin;
                isSpared = false;
            }
            else
            {
                currentScore += pin;
            }
                
            prvPin = pin;

            return;
        }

        public int score()
        {
            return currentScore;
        }
    }
}