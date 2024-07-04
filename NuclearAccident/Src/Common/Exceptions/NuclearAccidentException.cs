namespace NuclearAccident.Src.Common.Exceptions
{
    public class NuclearAccidentException(string message, Exception exception) : Exception(message, exception)
    {
    }
}
