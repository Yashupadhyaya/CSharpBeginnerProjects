using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace YourNamespace // Replace with the appropriate namespace
{
    // Replace 'FileQuizQuestionSerializer' with the correct class name and make sure it is in the same namespace
    public class FileQuizQuestionSerializer
    {
        public void SetGuids(List<QuizQuestion> questions)
        {
            if (questions != null)
            {
                foreach (var question in questions)
                {
                    question.Id = Guid.NewGuid();
                    if (question.Answers != null)
                    {
                        foreach (var answer in question.Answers)
                        {
                            answer.Id = Guid.NewGuid();
                        }
                    }
                }
            }
        }
    }

    public class QuizQuestion
    {
        public Guid Id { get; set; }
        public List<QuizQuestionAnswer> Answers { get; set; }
    }

    public class QuizQuestionAnswer
    {
        public Guid Id { get; set; }
    }

    [TestFixture]
    public class FileQuizQuestionSerializer_SetGuids_Test
    {
        private FileQuizQuestionSerializer serializer;

        [SetUp]
        public void SetUp()
        {
            serializer = new FileQuizQuestionSerializer();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up any resources used during testing
        }

        [Test]
        public void SetGuids_UpdatesQuestionIdAndAnswerIds()
        {
            // Arrange
            var questions = new List<QuizQuestion>()
            {
                new QuizQuestion
                {
                    Id = Guid.Empty,
                    Answers = new List<QuizQuestionAnswer>
                    {
                        new QuizQuestionAnswer
                        {
                            Id = Guid.Empty
                        },
                        new QuizQuestionAnswer
                        {
                            Id = Guid.Empty
                        }
                    }
                },
                new QuizQuestion
                {
                    Id = Guid.Empty,
                    Answers = new List<QuizQuestionAnswer>
                    {
                        new QuizQuestionAnswer
                        {
                            Id = Guid.Empty
                        }
                    }
                }
            };

            // Act
            serializer.SetGuids(questions);

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
        public void SetGuids_DoesNotUpdateQuestionIdAndAnswerIds_WhenQuestionsIsNull()
        {
            // Arrange
            List<QuizQuestion> questions = null;

            // Act
            serializer.SetGuids(questions);

            // Assert
            Assert.IsNull(questions);
        }

        [Test]
        public void SetGuids_DoesNotUpdateQuestionIdAndAnswerIds_WhenQuestionsIsEmpty()
        {
            // Arrange
            var questions = new List<QuizQuestion>();

            // Act
            serializer.SetGuids(questions);

            // Assert
            Assert.IsEmpty(questions);
        }
    }
}
