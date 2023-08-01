using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace LunarDoggo.QuizGame
{
    public class QuizGameTests
    {
        private QuizGame quizGame;

        [SetUp]
        public void Setup()
        {
            quizGame = new QuizGame();
            quizGame.unansweredQuestions.Add(new Question("Question 1", new List<string> { "Answer 1", "Answer 2", "Answer 3" }));
            quizGame.unansweredQuestions.Add(new Question("Question 2", new List<string> { "Answer 1", "Answer 2", "Answer 3" }));
            quizGame.unansweredQuestions.Add(new Question("Question 3", new List<string> { "Answer 1", "Answer 2", "Answer 3" }));
        }

        [Test]
        public void Test_MoveToNextQuestion_WhenUnansweredQuestionsExist()
        {
            int initialQuestionCount = quizGame.unansweredQuestions.Count;
            quizGame.MoveToNextQuestion();
            Assert.AreEqual(initialQuestionCount - 1, quizGame.unansweredQuestions.Count);
            Assert.IsTrue(quizGame.CurrentQuestion != null);
            Assert.IsFalse(quizGame.IsCurrentQuestionAnswered);
            Assert.AreEqual(0, quizGame.highlightedAnswerIndex);
            Assert.IsNull(quizGame.ChosenAnswer);
        }

        [Test]
        public void Test_MoveToNextQuestion_WhenNoUnansweredQuestionsExist()
        {
            quizGame.unansweredQuestions.Clear();
            quizGame.MoveToNextQuestion();
            Assert.IsNull(quizGame.CurrentQuestion);
            Assert.IsFalse(quizGame.IsCurrentQuestionAnswered);
            Assert.AreEqual(0, quizGame.highlightedAnswerIndex);
            Assert.IsNull(quizGame.ChosenAnswer);
        }
    }

    public class Question
    {
        public string Text { get; private set; }
        public List<string> Answers { get; private set; }

        public Question(string text, List<string> answers)
        {
            Text = text;
            Answers = answers;
        }
    }

    public class QuizGame
    {
        public List<Question> unansweredQuestions = new List<Question>();
        public Question CurrentQuestion { get; set; }
        public bool IsCurrentQuestionAnswered { get; set; }
        public int highlightedAnswerIndex { get; set; }
        public string ChosenAnswer { get; set; }

        private Random random = new Random();

        public void MoveToNextQuestion()
        {
            if (HasUnansweredQuestions)
            {
                int questionIndex = random.Next(0, unansweredQuestions.Count);
                CurrentQuestion = unansweredQuestions[questionIndex];
                IsCurrentQuestionAnswered = false;
                highlightedAnswerIndex = 0;
                ChosenAnswer = null;
            }
        }

        public bool HasUnansweredQuestions
        {
            get { return unansweredQuestions.Count > 0; }
        }
    }
}
