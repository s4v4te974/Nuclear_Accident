namespace NuclearAccident.Src.Common.Exceptions
{
    public class NuclearInccidentException(string message, Exception exception) : Exception(message, exception)
    {
    }
}
