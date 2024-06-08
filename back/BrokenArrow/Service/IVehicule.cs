namespace BrokenArrow.Service
{
    public interface IVehicule
    {

        Task<IEnumerable<IVehicule>> retrieveAllVehicules();

    }
}
