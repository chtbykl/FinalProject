namespace Core.Utilities.Results
{
    // temel voidler için başlangıç
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
