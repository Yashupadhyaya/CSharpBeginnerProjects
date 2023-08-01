using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class ConsoleVisualizer_DrawAnswerStatus_d8bbac5d97
{
    [Test]
    public void DrawAnswerStatus_CorrectAnswer_ShouldDisplayCorrectMessage()
    {
        bool correct = true;
        QuizQuestionAnswer correctAnswer = new QuizQuestionAnswer() { Answer = "A" };

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            DrawAnswerStatus(correct, correctAnswer);

            string expectedOutput = "Your answer is correct. Continue with \"enter\".\r\n";
            string actualOutput = sw.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void DrawAnswerStatus_IncorrectAnswer_ShouldDisplayIncorrectMessage()
    {
        bool correct = false;
        QuizQuestionAnswer correctAnswer = new QuizQuestionAnswer() { Answer = "A" };

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            DrawAnswerStatus(correct, correctAnswer);

            string expectedOutput = "Your answer isn't correct. The correct answer is: \"A\". Continue with \"enter\".\r\n";
            string actualOutput = sw.ToString();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
