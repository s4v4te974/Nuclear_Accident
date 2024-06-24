namespace MilitaryNuclearAccident.Src.Mna.Common.Exceptions
{
    public class BrokenArrowException(string message, Exception exception) : Exception(message, exception)
    {
    }
}
