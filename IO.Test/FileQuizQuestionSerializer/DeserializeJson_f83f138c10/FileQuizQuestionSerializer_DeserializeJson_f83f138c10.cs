using NUnit.Framework;
using System.Collections.Generic;
using System.Text.Json;

namespace YourTestProjectNamespace
{
    [TestFixture]
    public class FileQuizQuestionSerializer_DeserializeJson_f83f138c10
    {
        private FileQuizQuestionSerializer serializer;

        [SetUp]
        public void Setup()
        {
            serializer = new FileQuizQuestionSerializer();
        }

        [Test]
        public void DeserializeJson_WhenValidJsonContent_ReturnsQuizQuestionArray()
        {
            string content = "[{\"Question\":\"What is the capital of France?\",\"Answer\":\"Paris\"},{\"Question\":\"Who painted the Mona Lisa?\",\"Answer\":\"Leonardo da Vinci\"}]";
            IEnumerable<QuizQuestion> result = serializer.DeserializeJson(content);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<QuizQuestion>>(result);
        }

        [Test]
        public void DeserializeJson_WhenJsonContentWithComments_ReturnsQuizQuestionArrayIgnoringComments()
        {
            string content = "[{\"Question\":\"What is the capital of France?\",\"Answer\":\"Paris\"}, /* This is a comment */ {\"Question\":\"Who painted the Mona Lisa?\",\"Answer\":\"Leonardo da Vinci\"}]";
            IEnumerable<QuizQuestion> result = serializer.DeserializeJson(content);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<QuizQuestion>>(result);
        }

        [Test]
        public void DeserializeJson_WhenJsonContentWithDifferentCasing_ReturnsQuizQuestionArrayIgnoringPropertyNameCase()
        {
            string content = "[{\"question\":\"What is the capital of France?\",\"answer\":\"Paris\"},{\"question\":\"Who painted the Mona Lisa?\",\"answer\":\"Leonardo da Vinci\"}]";
            IEnumerable<QuizQuestion> result = serializer.DeserializeJson(content);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<QuizQuestion>>(result);
        }

        [Test]
        public void DeserializeJson_WhenJsonContentWithTrailingCommas_ReturnsQuizQuestionArrayIgnoringTrailingCommas()
        {
            string content = "[{\"Question\":\"What is the capital of France?\",\"Answer\":\"Paris\",}, {\"Question\":\"Who painted the Mona Lisa?\",\"Answer\":\"Leonardo da Vinci\",}]";
            IEnumerable<QuizQuestion> result = serializer.DeserializeJson(content);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<QuizQuestion>>(result);
        }

        [Test]
        public void DeserializeJson_WhenJsonContentWithNullValues_ReturnsQuizQuestionArrayIgnoringNullValues()
        {
            string content = "[{\"Question\":\"What is the capital of France?\",\"Answer\":null},{\"Question\":\"Who painted the Mona Lisa?\",\"Answer\":\"Leonardo da Vinci\"}]";
            IEnumerable<QuizQuestion> result = serializer.DeserializeJson(content);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<QuizQuestion>>(result);
        }
    }
}
