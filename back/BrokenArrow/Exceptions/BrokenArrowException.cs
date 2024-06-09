namespace BrokenArrow.Exceptions
{
    public class BrokenArrowException(string message, Exception exception) : Exception(message, exception)
    {
    }
}
