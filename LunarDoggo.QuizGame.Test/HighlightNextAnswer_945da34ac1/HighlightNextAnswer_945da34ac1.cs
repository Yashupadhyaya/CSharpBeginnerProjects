// ********RoostGPT********
// Test generated by RoostGPT for test csharp-testing using AI Type Open AI and AI Model gpt-4



// ********RoostGPT********
using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.QuizGame;

namespace LunarDoggo.QuizGame.Test
{
    public class HighlightNextAnswer_945da34ac1
    {
        [Test]
        public void HighlightNextAnswer_EmptyQuestionList_HighlightedAnswerIsNull()
        {
            // Arrange
            GameState gameState = new GameState(new List<QuizQuestion>());

            // Act
            gameState.HighlightNextAnswer();

            // Assert
            Assert.IsNull(gameState.HighlightedAnswer);
        }

        [Test]
        public void HighlightNextAnswer_OneQuestion_HighlightedAnswerIsFirst()
        {
            // Arrange
            QuizQuestion quizQuestion = new QuizQuestion
            {
                Answers = new QuizQuestionAnswer[]
                {
                    new QuizQuestionAnswer { Answer = "Answer1", IsCorrect = false },
                    new QuizQuestionAnswer { Answer = "Answer2", IsCorrect = true },
                }
            };
            GameState gameState = new GameState(new List<QuizQuestion> { quizQuestion });

            // Act
            gameState.MoveToNextQuestion();
            gameState.HighlightNextAnswer();

            // Assert
            Assert.AreEqual(quizQuestion.Answers[1], gameState.HighlightedAnswer);
        }

        [Test]
        public void HighlightNextAnswer_TwoQuestions_HighlightedAnswerIsFirst()
        {
            // Arrange
            QuizQuestion quizQuestion1 = new QuizQuestion
            {
                Answers = new QuizQuestionAnswer[]
                {
                    new QuizQuestionAnswer { Answer = "Answer1", IsCorrect = false },
                    new QuizQuestionAnswer { Answer = "Answer2", IsCorrect = true },
                }
            };
            QuizQuestion quizQuestion2 = new QuizQuestion
            {
                Answers = new QuizQuestionAnswer[]
                {
                    new QuizQuestionAnswer { Answer = "Answer3", IsCorrect = false },
                    new QuizQuestionAnswer { Answer = "Answer4", IsCorrect = true },
                }
            };
            GameState gameState = new GameState(new List<QuizQuestion> { quizQuestion1, quizQuestion2 });

            // Act
            gameState.MoveToNextQuestion();
            gameState.HighlightNextAnswer();
            gameState.MoveToNextQuestion();
            gameState.HighlightNextAnswer();

            // Assert
            Assert.AreEqual(quizQuestion2.Answers[1], gameState.HighlightedAnswer);
        }
    }
}
