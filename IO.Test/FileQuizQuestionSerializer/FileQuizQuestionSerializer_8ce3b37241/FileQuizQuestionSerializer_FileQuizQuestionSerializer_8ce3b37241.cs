using NUnit.Framework;

[TestFixture]
public class FileQuizQuestionSerializer_FileQuizQuestionSerializer_8ce3b37241
{
    [Test]
    public void Constructor_InitializesFilePath()
    {
        string filePath = "example.txt";
        FileQuizQuestionSerializer serializer = new FileQuizQuestionSerializer(filePath);
        Assert.AreEqual(filePath, serializer.filePath);
    }

    [Test]
    public void Constructor_NullFilePath_ThrowsArgumentNullException()
    {
        string filePath = null;
        Assert.Throws<ArgumentNullException>(() => new FileQuizQuestionSerializer(filePath));
    }
}
