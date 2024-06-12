using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class is_GameState_411dc2bb34
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorrectAnswer { get; set; }

        public QuizQuestion(string question, string option1, string option2, string option3, string option4, int correctAnswer)
        {
            Question = question;
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
            CorrectAnswer = correctAnswer;
        }
    }

    public class GameState
    {
        public List<QuizQuestion> unansweredQuestions;

        public int TotalQuestionCount
        {
            get { return unansweredQuestions.Count; }
        }

        public GameState(List<QuizQuestion> questions)
        {
            unansweredQuestions = new List<QuizQuestion>();
            unansweredQuestions.AddRange(questions);
        }
    }

    [Test]
    public void GameState_InitializeWithQuestions_AddsQuestionsAndSetsTotalCount()
    {
        // Arrange
        var questions = new List<QuizQuestion>
        {
            new QuizQuestion("Question 1", "Option 1", "Option 2", "Option 3", "Option 4", 1),
            new QuizQuestion("Question 2", "Option 1", "Option 2", "Option 3", "Option 4", 2),
            new QuizQuestion("Question 3", "Option 1", "Option 2", "Option 3", "Option 4", 3)
        };

        // Act
        var gameState = new GameState(questions);

        // Assert
        Assert.AreEqual(3, gameState.TotalQuestionCount);
        Assert.AreEqual(questions, gameState.unansweredQuestions);
    }

    [Test]
    public void GameState_InitializeWithNoQuestions_DoesNotAddQuestions()
    {
        // Arrange
        var questions = new List<QuizQuestion>();

        // Act
        var gameState = new GameState(questions);

        // Assert
        Assert.AreEqual(0, gameState.TotalQuestionCount);
        Assert.IsEmpty(gameState.unansweredQuestions);
    }

    [Test]
    public void GameState_InitializeWithNullQuestions_DoesNotAddQuestions()
    {
        // Arrange
        List<QuizQuestion> questions = null;

        // Act
        var gameState = new GameState(questions);

        // Assert
        Assert.AreEqual(0, gameState.TotalQuestionCount);
        Assert.IsEmpty(gameState.unansweredQuestions);
    }
}
