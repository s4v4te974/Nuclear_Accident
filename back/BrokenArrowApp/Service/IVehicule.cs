namespace BrokenArrowApp.Service
{
    public interface IVehicule
    {

        Task<IEnumerable<IVehicule>> retrieveAllVehicules();

    }
}
