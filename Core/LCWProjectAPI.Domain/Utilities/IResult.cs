namespace EntityLayer.Concrete.Utilities
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
