using System;
using NUnit.Framework;

// Assuming that TicTacToe and Player classes are defined in the same namespace
namespace TicTacToeTests
{
    // Definition of TicTacToe class
    public class TicTacToe
    {
        // Definition of Player class
        public class Player
        {
            public string Name { get; set; }
            public char Symbol { get; set; }

            public Player(string name, char symbol)
            {
                Name = name;
                Symbol = symbol;
            }
        }

        // Definition of PlayerEventArgs class
        public class PlayerEventArgs : EventArgs
        {
            public Player Player { get; private set; }

            public PlayerEventArgs(Player player)
            {
                if (player == null)
                    throw new ArgumentNullException(nameof(player));

                Player = player;
            }
        }
    }

    [TestFixture]
    public class PlayerEventArgsTests
    {
        [Test]
        public void Testis_PlayerEventArgs_25302f0712_NullPlayer()
        {
            TicTacToe.Player player = null;
            var ex = Assert.Throws<ArgumentNullException>(() => new TicTacToe.PlayerEventArgs(player));
            Assert.That(ex.ParamName, Is.EqualTo("player"));
        }

        [Test]
        public void Testis_PlayerEventArgs_25302f0712_ValidPlayer()
        {
            TicTacToe.Player player = new TicTacToe.Player("John", 'X');
            TicTacToe.PlayerEventArgs playerEventArgs = new TicTacToe.PlayerEventArgs(player);
            Assert.That(playerEventArgs.Player, Is.EqualTo(player));
        }
    }
}
