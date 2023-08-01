using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class Program_RunGameLoop_Test
{
    [Test]
    public void RunGameLoop_WithEmptyQuestions_ShouldFinishGame()
    {
        // Arrange
        List<QuizQuestion> questions = new List<QuizQuestion>();

        // Act
        Program.RunGameLoop(questions);

        // Assert
        Assert.IsTrue(Program.Visualizer.IsPlayAgainCalled, "PlayAgain should be called");
        Assert.IsTrue(Program.Visualizer.DrawPlayAgainCalled, "DrawPlayAgain should be called");
    }

    [Test]
    public void RunGameLoop_WithOneQuestion_ShouldFinishGame()
    {
        // Arrange
        List<QuizQuestion> questions = new List<QuizQuestion>
        {
            new QuizQuestion("What is the capital of France?", "Paris")
        };

        // Act
        Program.RunGameLoop(questions);

        // Assert
        Assert.IsTrue(Program.Visualizer.IsPlayAgainCalled, "PlayAgain should be called");
        Assert.IsTrue(Program.Visualizer.DrawPlayAgainCalled, "DrawPlayAgain should be called");
    }

    [Test]
    public void RunGameLoop_WithMultipleQuestions_ShouldFinishGame()
    {
        // Arrange
        List<QuizQuestion> questions = new List<QuizQuestion>
        {
            new QuizQuestion("What is the capital of France?", "Paris"),
            new QuizQuestion("Who painted the Mona Lisa?", "Leonardo da Vinci"),
            new QuizQuestion("What is the largest planet in our solar system?", "Jupiter")
        };

        // Act
        Program.RunGameLoop(questions);

        // Assert
        Assert.IsTrue(Program.Visualizer.IsPlayAgainCalled, "PlayAgain should be called");
        Assert.IsTrue(Program.Visualizer.DrawPlayAgainCalled, "DrawPlayAgain should be called");
    }
}
