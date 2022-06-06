namespace EntityLayer.Concrete.Utilities
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }
    }
}
