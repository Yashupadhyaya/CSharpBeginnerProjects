using NUnit.Framework;
using System;
using System.Collections.Generic;

public class GameState
{
    public bool HasUnansweredQuestions { get; set; }
    public List<string> unansweredQuestions { get; set; }
    public string CurrentQuestion { get; set; }
    public int highlightedAnswerIndex { get; set; }
    public string ChosenAnswer { get; set; }
    public bool IsCurrentQuestionAnswered { get; set; }

    public void MoveToNextQuestion()
    {
        if (HasUnansweredQuestions && unansweredQuestions.Count > 0)
        {
            CurrentQuestion = unansweredQuestions[0];
            IsCurrentQuestionAnswered = false;
            highlightedAnswerIndex = 0;
            ChosenAnswer = null;
            unansweredQuestions.RemoveAt(0);
        }
        else
        {
            CurrentQuestion = null;
        }
    }
}

[TestFixture]
public class MoveToNextQuestionTests
{
    private GameState gameState;

    [SetUp]
    public void Setup()
    {
        gameState = new GameState();
    }

    [TearDown]
    public void Teardown()
    {
        gameState = null;
    }

    [Test]
    public void MoveToNextQuestion_WhenUnansweredQuestionsExist_ShouldSetCurrentQuestion()
    {
        gameState.HasUnansweredQuestions = true;
        gameState.unansweredQuestions = new List<string> { "Question 1", "Question 2" };

        gameState.MoveToNextQuestion();

        Assert.IsNotNull(gameState.CurrentQuestion);
    }

    [Test]
    public void MoveToNextQuestion_WhenUnansweredQuestionsExist_ShouldResetLastQuestionData()
    {
        gameState.HasUnansweredQuestions = true;
        gameState.CurrentQuestion = "Previous Question";
        gameState.highlightedAnswerIndex = 2;
        gameState.ChosenAnswer = "Previous Answer";

        gameState.MoveToNextQuestion();

        Assert.IsFalse(gameState.IsCurrentQuestionAnswered);
        Assert.AreEqual(0, gameState.highlightedAnswerIndex);
        Assert.IsNull(gameState.ChosenAnswer);
    }

    [Test]
    public void MoveToNextQuestion_WhenNoUnansweredQuestionsExist_ShouldNotSetCurrentQuestion()
    {
        gameState.HasUnansweredQuestions = false;
        gameState.unansweredQuestions = new List<string>();

        gameState.MoveToNextQuestion();

        Assert.IsNull(gameState.CurrentQuestion);
    }
}
