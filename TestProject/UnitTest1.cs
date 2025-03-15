using System;
using Xunit;
using GuessTheNumber;

namespace TestProject
{ 
    public class GameTests
    {
        [Fact]
        public void TestGuess_LowerNumber()
        {
            var testGame = new TestableGame(50); 
            var result = testGame.Guess(30);
            Assert.Equal("�������� ����� �����!", result);
        }

        [Fact]
        public void TestGuess_HigherNumber()
        {
            var testGame = new TestableGame(50);
            var result = testGame.Guess(70);
            Assert.Equal("�������� ����� �����!", result);
        }

        [Fact]
        public void TestGuess_CorrectGuess()
        {
            var testGame = new TestableGame(50);
            var result = testGame.Guess(50);
            Assert.Equal("³����! �� ������� ����� �� 1 �����.", result);
        }

        [Fact]
        public void TestMultipleGuesses()
        {
            var testGame = new TestableGame(50);
            testGame.Guess(30);
            var result = testGame.Guess(70);
            Assert.Equal("�������� ����� �����!", result);
        }

        [Fact]
        public void TestAttemptsCounter()
        {
            var testGame = new TestableGame(50);
            testGame.Guess(30);
            testGame.Guess(70);
            testGame.Guess(50);
            Assert.Equal(3, testGame.GetAttempts());
        }
    }

    public class TestableGame : Game
    {
        private readonly int _fixedNumber;

        public TestableGame(int fixedNumber) : base()
        {
            _fixedNumber = fixedNumber;
        }

        public new string Guess(int userGuess)
        {
            return userGuess < _fixedNumber
                ? "�������� ����� �����!"
                : userGuess > _fixedNumber
                    ? "�������� ����� �����!"
                    : $"³����! �� ������� ����� �� {GetAttempts()} �����.";
        }
    }
}
