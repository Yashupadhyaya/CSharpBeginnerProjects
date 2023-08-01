using NUnit.Framework;
using System.IO;

namespace LunarDoggo.QuizGame.IO.Tests
{
    [TestFixture]
    public class FileQuizQuestionSerializerTests
    {
        private string filePath;
        private FileQuizQuestionSerializer serializer;

        [SetUp]
        public void Setup()
        {
            filePath = "path/to/test/file";
            serializer = new FileQuizQuestionSerializer(filePath);
        }

        [Test]
        public void TestFileQuizQuestionSerializer_FileQuizQuestionSerializer_Success()
        {
            Assert.AreEqual(filePath, serializer.filePath);
        }

        [Test]
        public void TestFileQuizQuestionSerializer_FileQuizQuestionSerializer_NullFilePath()
        {
            Assert.Throws<ArgumentNullException>(() => new FileQuizQuestionSerializer(null));
        }

        [Test]
        public void TestFileQuizQuestionSerializer_FileQuizQuestionSerializer_EmptyFilePath()
        {
            Assert.Throws<FileNotFoundException>(() => new FileQuizQuestionSerializer(string.Empty));
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup code
        }
    }
}
