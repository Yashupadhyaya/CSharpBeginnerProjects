using NUnit.Framework;
using LunarDoggo.QuizGame.Visuals;
using System.Collections.Generic;
using System;

namespace LunarDoggo.QuizGame.Tests
{
    [TestFixture]
    public class QuizStateTests
    {
        private QuizState state;

        [SetUp]
        public void Setup()
        {
            this.state = new QuizState();
        }

        [Test]
        public void Test_ChangeHighlightedAnswer_When_CurrentQuestion_Is_Null_Should_Not_Change_Highlighted_Answer()
        {
            this.state.CurrentQuestion = null;
            bool isUp = true;
            this.state.ChangeHighlightedAnswer(isUp);
            Assert.IsNull(this.state.HighlightedAnswer);
        }

        [Test]
        public void Test_ChangeHighlightedAnswer_When_CurrentQuestion_Is_Answered_Should_Not_Change_Highlighted_Answer()
        {
            this.state.CurrentQuestion = new Question();
            this.state.IsCurrentQuestionAnswered = true;
            bool isUp = false;
            this.state.ChangeHighlightedAnswer(isUp);
            Assert.IsNull(this.state.HighlightedAnswer);
        }

        [Test]
        public void Test_ChangeHighlightedAnswer_When_Up_Is_True_Should_Highlight_Previous_Answer()
        {
            this.state.CurrentQuestion = new Question();
            this.state.CurrentQuestion.Answers = new List<Answer>()
            {
                new Answer(),
                new Answer()
            };
            bool isUp = true;
            this.state.ChangeHighlightedAnswer(isUp);
            Assert.AreEqual(this.state.CurrentQuestion.Answers[0], this.state.HighlightedAnswer);
        }

        [Test]
        public void Test_ChangeHighlightedAnswer_When_Up_Is_False_Should_Highlight_Next_Answer()
        {
            this.state.CurrentQuestion = new Question();
            this.state.CurrentQuestion.Answers = new List<Answer>()
            {
                new Answer(),
                new Answer()
            };
            bool isUp = false;
            this.state.ChangeHighlightedAnswer(isUp);
            Assert.AreEqual(this.state.CurrentQuestion.Answers[1], this.state.HighlightedAnswer);
        }
    }
}
