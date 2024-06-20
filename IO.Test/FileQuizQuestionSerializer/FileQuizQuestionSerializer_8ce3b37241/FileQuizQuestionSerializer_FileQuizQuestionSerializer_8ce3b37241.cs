using NUnit.Framework;
using LunarDoggo.QuizGame.IO;
using System.IO;

namespace LunarDoggo.QuizGame.IO.Test
{
    [TestFixture]
    public class FileQuizQuestionSerializerTests
    {
        private string validFilePath;
        private string invalidFilePath;

        [SetUp]
        public void Setup()
        {
            // TODO: Replace with a valid file path
            this.validFilePath = @"C:\temp\validFile.txt";

            // TODO: Replace with an invalid file path
            this.invalidFilePath = @"C:\temp\invalidFile.txt";
        }

        [Test]
        public void FileQuizQuestionSerializer_ValidFilePath_Success()
        {
            FileQuizQuestionSerializer serializer = new FileQuizQuestionSerializer(validFilePath);
            Assert.IsNotNull(serializer);
        }

        [Test]
        public void FileQuizQuestionSerializer_InvalidFilePath_ThrowsFileNotFoundException()
        {
            var ex = Assert.Throws<FileNotFoundException>(() => new FileQuizQuestionSerializer(invalidFilePath));
            Assert.That(ex.Message, Is.EqualTo($"Could not find file '{invalidFilePath}'."));
        }
    }
}
