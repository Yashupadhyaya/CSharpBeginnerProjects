using NUnit.Framework;

public class is_ChangeHighlightedAnswer_7aa356a4b6
{
    private Questionnaire questionnaire;

    [SetUp]
    public void Setup()
    {
        questionnaire = new Questionnaire();
        questionnaire.CurrentQuestion = new Question();
        questionnaire.CurrentQuestion.Answers = new string[] { "Answer 1", "Answer 2", "Answer 3" };
        questionnaire.HighlightedAnswerIndex = 0;
    }

    [Test]
    public void ChangeHighlightedAnswer_IncrementIndexWithinBounds_HighlightedAnswerIndexChanges()
    {
        int indexIncrement = 1;
        questionnaire.ChangeHighlightedAnswer(indexIncrement);
        Assert.AreEqual(1, questionnaire.HighlightedAnswerIndex);
    }

    [Test]
    public void ChangeHighlightedAnswer_IncrementIndexOutOfBounds_IndexResetsToZero()
    {
        int indexIncrement = 2;
        questionnaire.ChangeHighlightedAnswer(indexIncrement);
        Assert.AreEqual(0, questionnaire.HighlightedAnswerIndex);
    }

    [Test]
    public void ChangeHighlightedAnswer_DecrementIndexOutOfBounds_IndexResetsToAnswerCountMinusOne()
    {
        int indexIncrement = -1;
        questionnaire.ChangeHighlightedAnswer(indexIncrement);
        Assert.AreEqual(questionnaire.CurrentQuestion.Answers.Length - 1, questionnaire.HighlightedAnswerIndex);
    }
}

public class Questionnaire
{
    public Question CurrentQuestion { get; set; }
    public int HighlightedAnswerIndex { get; set; }

    public void ChangeHighlightedAnswer(int indexIncrement)
    {
        int answerCount = this.CurrentQuestion.Answers.Length;
        this.HighlightedAnswerIndex += indexIncrement;

        if (this.HighlightedAnswerIndex >= answerCount)
        {
            this.HighlightedAnswerIndex = 0;
        }
        else if (this.HighlightedAnswerIndex < 0)
        {
            this.HighlightedAnswerIndex = answerCount - 1;
        }
    }
}

public class Question
{
    public string[] Answers { get; set; }
}
