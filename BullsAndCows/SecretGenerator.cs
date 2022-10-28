using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private Random random
            ;

        public SecretGenerator()
        {
        }

        public SecretGenerator(Random random)
        {
            this.random = random;
        }

        public virtual string GenerateSecret()
        {
            var randomSet = new HashSet<int>();
            while (randomSet.Count < 4)
            {
                var x = random.Next(10);
                randomSet.Add(x);
            }

            return string.Join(" ", randomSet);
        }
    }
}