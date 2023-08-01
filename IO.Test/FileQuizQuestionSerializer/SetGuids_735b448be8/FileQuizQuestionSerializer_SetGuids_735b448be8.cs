using NUnit.Framework;
using LunarDoggo.QuizGame.IO;
using System;
using System.Collections.Generic;

namespace LunarDoggo.QuizGame.IO.Tests
{
    [TestFixture]
    public class TestFileQuizQuestionSerializer
    {
        private FileQuizQuestionSerializer serializer;
      
        [SetUp]
        public void SetUp()
        {
            this.serializer = new FileQuizQuestionSerializer("");
        }
        
        [Test]
        public void TestFileQuizQuestionSerializer_SetGuids_735b448be8()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = Guid.Empty,
                    Answers = new List<QuizQuestionAnswer>
                    {
                        new QuizQuestionAnswer { Id = Guid.Empty },
                        new QuizQuestionAnswer { Id = Guid.Empty },
                        new QuizQuestionAnswer { Id = Guid.Empty }
                    }
                },
                new QuizQuestion
                {
                    Id = Guid.Empty,
                    Answers = new List<QuizQuestionAnswer>
                    {
                        new QuizQuestionAnswer { Id = Guid.Empty },
                        new QuizQuestionAnswer { Id = Guid.Empty },
                        new QuizQuestionAnswer { Id = Guid.Empty }
                    }
                },
            };

            serializer.SetGuids(questions);
            
            foreach(QuizQuestion question in questions)
            {
                Assert.AreNotEqual(Guid.Empty, question.Id);
                
                foreach(QuizQuestionAnswer answer in question.Answers)
                {
                    Assert.AreNotEqual(Guid.Empty, answer.Id);
                }
            }
        }
        
        [Test]
        public void TestFileQuizQuestionSerializer_SetGuids_NullQuestions()
        {
            List<QuizQuestion> questions = null;
            
            TestDelegate testDelegate = () => serializer.SetGuids(questions);
            
            Assert.Throws<ArgumentNullException>(testDelegate);
        }
    }
}
