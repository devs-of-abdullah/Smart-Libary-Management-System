using Entity;

namespace Business.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task ReserveBookAsync(Reservation reservation);
        Task DeleteReservationAsync(int id);
        Task<Reservation?> GetReservationByIdAsync(int id);
    }
}
