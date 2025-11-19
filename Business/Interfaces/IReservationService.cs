using Entity;

namespace Business.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task ReserveBookAsync(Reservation reservation);
    }
}
