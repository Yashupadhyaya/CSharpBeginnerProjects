using NUnit.Framework;
using System.Collections.Generic;
using LunarDoggo.QuizGame.IO;
using System;
using System.IO;
using System.Linq;

namespace LunarDoggo.QuizGame.IO.Test
{
    [TestFixture]
    public class FileQuizQuestionSerializer_DeserializeQuestions_4bbf2ded22
    {
        private FileQuizQuestionSerializer fileQuizQuestionSerializer;
        private string filePath;

        [SetUp]
        public void SetUp()
        {
            this.filePath = "test.json"; 
            this.fileQuizQuestionSerializer = new FileQuizQuestionSerializer(filePath);
        }

        [Test]
        public void DeserializeQuestions_ValidFile_ReturnsQuestions()
        {
            IEnumerable<QuizQuestion> result = fileQuizQuestionSerializer.DeserializeQuestions();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void DeserializeQuestions_InvalidFile_ThrowsException()
        {
            Assert.Throws<Exception>(() => fileQuizQuestionSerializer.DeserializeQuestions());
        }

        [Test]
        public void DeserializeQuestions_EmptyFile_ReturnsEmpty()
        {
            IEnumerable<QuizQuestion> result = fileQuizQuestionSerializer.DeserializeQuestions();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(this.filePath))
            {
                File.Delete(this.filePath);
            }
        }
    }
}
