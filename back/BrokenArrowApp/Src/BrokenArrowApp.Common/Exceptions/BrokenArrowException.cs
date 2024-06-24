namespace BrokenArrowApp.Src.BrokenArrowApp.Common.Exceptions
{
    public class BrokenArrowException(string message, Exception exception) : Exception(message, exception)
    {
    }
}
