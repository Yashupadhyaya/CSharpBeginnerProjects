using NUnit.Framework;
using System.IO;

namespace LunarDoggo.QuizGame.IO
{
    [TestFixture]
    public class FileQuizQuestionSerializerTests
    {
        private FileQuizQuestionSerializer serializer;

        [SetUp]
        public void SetUp()
        {
            serializer = new FileQuizQuestionSerializer("enter_file_path_here");
        }

        [Test]
        public void TestFileQuizQuestionSerializer_GetFileContent_FileExists_ReturnsFileContent()
        {
            string filePath = "path/to/existing/file.txt";
            string expectedContent = "This is the content of the file.";
            string actualContent = serializer.GetFileContent(filePath);
            Assert.AreEqual(expectedContent, actualContent);
        }

        [Test]
        public void TestFileQuizQuestionSerializer_GetFileContent_FileDoesNotExist_ReturnsEmptyString()
        {
            string filePath = "path/to/non/existing/file.txt";
            string expectedContent = string.Empty;
            string actualContent = serializer.GetFileContent(filePath);
            Assert.AreEqual(expectedContent, actualContent);
        }
    }
}
