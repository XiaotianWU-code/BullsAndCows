using BullsAndCows;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_return_secret_with_4_character_when_generate_secret()
        {
            // given
            SecretGenerator secretGenerator = new SecretGenerator();
            // when
            var secret = secretGenerator.GenerateSecret();
            // then
            Assert.Equal(4, secret.Split(" ").Length);
        }

        [Fact]
        public void Should_return_secret_with_4_random_and_each_digits_is_different_when_generate_secret()
        {
            // given
            Mock<Random> mocKRandom = new Mock<Random>();
            mocKRandom.SetupSequence(x => x.Next(It.IsAny<int>())).Returns(1).Returns(1).Returns(5).Returns(4).Returns(4).Returns(3);
            SecretGenerator secretGenerator = new SecretGenerator(mocKRandom.Object);
            // when
            var secret = secretGenerator.GenerateSecret();
            // then
            Assert.Equal("1 5 4 3", secret);
        }
    }
}