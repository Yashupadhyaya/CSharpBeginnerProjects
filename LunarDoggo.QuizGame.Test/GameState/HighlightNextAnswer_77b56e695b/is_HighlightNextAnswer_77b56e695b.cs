using NUnit.Framework;

namespace YourProject.Test
{
    [TestFixture]
    public class is_HighlightNextAnswer_77b56e695b
    {
        private YourClass _yourClass;

        [SetUp]
        public void SetUp()
        {
            _yourClass = new YourClass();
        }

        [Test]
        public void HighlightNextAnswer_ChangeHighlightedAnswerWithPositiveIndex_ShouldHighlightNextAnswer()
        {
            _yourClass.HighlightNextAnswer();
        }

        [Test]
        public void HighlightNextAnswer_ChangeHighlightedAnswerWithNegativeIndex_ShouldNotHighlightNextAnswer()
        {
            _yourClass.HighlightNextAnswer();
        }

        [Test]
        public void HighlightNextAnswer_ChangeHighlightedAnswerWithZeroIndex_ShouldNotHighlightNextAnswer()
        {
            _yourClass.HighlightNextAnswer();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
