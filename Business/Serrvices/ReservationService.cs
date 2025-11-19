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
    }
}
