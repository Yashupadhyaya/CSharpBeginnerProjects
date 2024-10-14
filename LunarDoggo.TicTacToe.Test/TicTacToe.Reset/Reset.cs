// ********RoostGPT********
/*
Test generated by RoostGPT for test chshapunit-testing using AI Type  and AI Model 

ROOST_METHOD_HASH=Reset_6d2e689bc2
ROOST_METHOD_SIG_HASH=Reset_d971311384

   ########## Test-Scenarios ##########  

Scenario 1: Reset Method on an Empty Game Board

Details:
  TestName: TestResetOnEmptyBoard
  Description: This test checks if the Reset method works correctly when called on an empty game board. All tiles should already be set to 0, thus the Reset method should maintain the initial state of the board.
Execution:
  Arrange: Create a new instance of the GameBoard class.
  Act: Call the Reset method on the GameBoard instance.
  Assert: Use NUnit assertions to check if all elements in the tiles array are 0.
Validation:
  The assertion validates that the Reset method correctly sets all tiles to 0, even if the board was already empty. This is significant in maintaining the consistency and correctness of the game state.

Scenario 2: Reset Method on a Partially Occupied Game Board

Details:
  TestName: TestResetOnPartiallyOccupiedBoard
  Description: This test checks the functionality of the Reset method when used on a game board that is partially occupied. The Reset method should set all tiles to 0, regardless of their initial state.
Execution:
  Arrange: Create a new instance of the GameBoard class and call the OccupyTile method to set some tiles to non-zero values.
  Act: Call the Reset method on the GameBoard instance.
  Assert: Use NUnit assertions to check if all elements in the tiles array are 0.
Validation:
  The assertion verifies that the Reset method correctly sets all tiles to 0, even if some tiles were initially set to non-zero values. This is important in ensuring that the game board can be correctly reset between games.

Scenario 3: Reset Method on a Fully Occupied Game Board

Details:
  TestName: TestResetOnFullyOccupiedBoard
  Description: This test checks the functionality of the Reset method when used on a fully occupied game board. Regardless of the initial state of the tiles, the Reset method should set all tiles to 0.
Execution:
  Arrange: Create a new instance of the GameBoard class and call the OccupyTile method to set all tiles to non-zero values.
  Act: Call the Reset method on the GameBoard instance.
  Assert: Use NUnit assertions to check if all elements in the tiles array are 0.
Validation:
  The assertion confirms that the Reset method correctly sets all tiles to 0, even if the board was fully occupied. This is crucial in ensuring that the game board can be correctly reset between games.


*/

// ********RoostGPT********
using NUnit.Framework;
using System;

namespace TicTacToe.Test
{
    public class ResetTest
    {
        private GameBoard gameBoard;

        [SetUp]
        public void Setup()
        {
            gameBoard = new GameBoard();
        }

        [Test]
        public void TestResetOnEmptyBoard()
        {
            gameBoard.Reset();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Assert.AreEqual(0, gameBoard.GetTile(x, y));
                }
            }
        }

        [Test]
        public void TestResetOnPartiallyOccupiedBoard()
        {
            Player player = new Player(1, "X");
            gameBoard.OccupyTile(player, 0, 0);
            
            gameBoard.Reset();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Assert.AreEqual(0, gameBoard.GetTile(x, y));
                }
            }
        }

        [Test]
        public void TestResetOnFullyOccupiedBoard()
        {
            Player player1 = new Player(1, "X");
            Player player2 = new Player(2, "O");

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    gameBoard.OccupyTile((x + y) % 2 == 0 ? player1 : player2, x, y);
                }
            }

            gameBoard.Reset();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Assert.AreEqual(0, gameBoard.GetTile(x, y));
                }
            }
        }
    }
}
