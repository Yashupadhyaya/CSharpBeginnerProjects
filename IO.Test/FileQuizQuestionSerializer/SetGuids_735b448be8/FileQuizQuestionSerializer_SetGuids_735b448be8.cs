// Test generated by RoostGPT for test test-csrepo using AI Type Open AI and AI Model gpt-4

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using LunarDoggo.QuizGame.IO;

namespace LunarDoggo.QuizGame.IO.Test
{
    [TestFixture]
    public class FileQuizQuestionSerializer_SetGuids_735b448be8
    {
        [Test]
        public void SetGuids_ShouldAssignNewGuids_WhenCalled()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Answers = new List<QuizQuestionAnswer> { new QuizQuestionAnswer(), new QuizQuestionAnswer() } },
                new QuizQuestion { Answers = new List<QuizQuestionAnswer> { new QuizQuestionAnswer(), new QuizQuestionAnswer() } }
            };

            // Act
            SetGuids(questions);

            // Assert
            foreach (var question in questions)
            {
                Assert.AreNotEqual(Guid.Empty, question.Id);
                foreach (var answer in question.Answers)
                {
                    Assert.AreNotEqual(Guid.Empty, answer.Id);
                }
            }
        }

        [Test]
        public void SetGuids_ShouldAssignDifferentGuids_WhenCalledMultipleTimes()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Answers = new List<QuizQuestionAnswer> { new QuizQuestionAnswer(), new QuizQuestionAnswer() } },
                new QuizQuestion { Answers = new List<QuizQuestionAnswer> { new QuizQuestionAnswer(), new QuizQuestionAnswer() } }
            };

            // Act
            SetGuids(questions);
            var firstRunGuids = ExtractGuids(questions);
            SetGuids(questions);
            var secondRunGuids = ExtractGuids(questions);

            // Assert
            CollectionAssert.AreNotEqual(firstRunGuids, secondRunGuids);
        }

        private void SetGuids(IEnumerable<QuizQuestion> questions)
        {
            foreach(QuizQuestion question in questions)
            {
                question.Id = Guid.NewGuid();
                foreach(QuizQuestionAnswer answer in question.Answers)
                {
                    answer.Id = Guid.NewGuid();
                }
            }
        }

        private List<Guid> ExtractGuids(IEnumerable<QuizQuestion> questions)
        {
            var guids = new List<Guid>();
            foreach (var question in questions)
            {
                guids.Add(question.Id);
                foreach (var answer in question.Answers)
                {
                    guids.Add(answer.Id);
                }
            }
            return guids;
        }
    }
}
