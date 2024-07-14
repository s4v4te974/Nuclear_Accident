namespace NuclearIncident.Src.Common.Exceptions
{
    public class NuclearIncidentException(string message, Exception exception) : Exception(message, exception)
    {
    }
}
