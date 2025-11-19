using Business.Interfaces;
using Data.Interfaces;
using Entity;

namespace Business.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepo;

        public ReservationService(IReservationRepository reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepo.GetAllAsync();
        }

        public async Task ReserveBookAsync(Reservation reservation)
        {
            await _reservationRepo.AddAsync(reservation);
           
        }
        public async Task DeleteReservationAsync(int Id)
        {
            await _reservationRepo.DeleteAsync(Id);
        }
        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            var result = await _reservationRepo.GetByIdAsync(id);
            if (result == null) return null;
            return result;
            
        }
    }
}
