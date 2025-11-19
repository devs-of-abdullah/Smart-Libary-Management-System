using Data.Interfaces;
using Business.Interfaces;
using Entity;

namespace Business.Services
{
   

    public class FineService : IFineService
    {
        private readonly IFineRepository _fineRepo;

        public FineService(IFineRepository fineRepo)
        {
            _fineRepo = fineRepo;
        }

        public async Task<IEnumerable<Fine>> GetAllFinesAsync()
        {
            return await _fineRepo.GetAllAsync();
        }

        public async Task<Fine?> GetFineByIdAsync(int id)
        {
            return await _fineRepo.GetByIdAsync(id);
        }

        public async Task AddFineAsync(Fine fine)
        {
            await _fineRepo.AddAsync(fine);
        }

        public async Task MarkFinePaidAsync(int id)
        {
            var fine = await _fineRepo.GetByIdAsync(id);
            if (fine == null) return;

            fine.IsPaid = true;
            fine.DatePaid = DateTime.UtcNow;
            await _fineRepo.UpdateAsync(fine);
        }
    }
}
