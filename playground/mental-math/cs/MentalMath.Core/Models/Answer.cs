namespace MentalMath.Core.Models;

public sealed class Answer
{
    public Answer(MathProblem mathProblem)
    {
        MathProblem = mathProblem;
        CreatedOn = DateTime.Now;
    }

    public MathProblem MathProblem { get; }
    public TimeSpan TimeTaken { get; private set; }
    public DateTime CreatedOn { get; }
    public int UserResult { get; private set; }
    public bool IsCorrect => MathProblem.Result == UserResult;

    public void SetUserResult(int userResult)
    {
        UserResult = userResult;
        TimeTaken = DateTime.Now - CreatedOn;
    }
}