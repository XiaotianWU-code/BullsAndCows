﻿using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;

        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessList = guess.Split(" ");
            var secretList = secret.Split(" ");
            var cntA = 0;
            for (var i = 0; i < secretList.Length; i++)
            {
                if (guessList[i] == secretList[i])
                {
                    cntA++;
                }
            }

            var intersect = guessList.Intersect(secretList).ToList().Count;

            var cntB = intersect - cntA;

            return $"{cntA}A{cntB}B";
        }
    }
}