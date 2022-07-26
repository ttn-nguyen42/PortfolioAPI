﻿using Microsoft.EntityFrameworkCore;

namespace Portfolio.Repositories
{
    public interface IVolunteeringRepository
    {
        public Task<Volunteering?> GetVolunteeringAsync(int id);

        public Task AddVolunteering(Volunteering volunteering);

        public void DeleteVolunteering(Volunteering volunteering);

        public Task<bool> SaveChangesAsync();
    }

    public class VolunteeringRepository : IVolunteeringRepository
    {
        private readonly PortfolioContext _context;

        public VolunteeringRepository(PortfolioContext context)
        {
            _context = context;
        }

        public async Task AddVolunteering(Volunteering volunteering)
        {
            await _context.Volunteerings.AddAsync(volunteering);
        }

        public void DeleteVolunteering(Volunteering volunteering)
        {
            _context.Volunteerings.Remove(volunteering);
        }

        public async Task<Volunteering?> GetVolunteeringAsync(int id)
        {
            return await _context.Volunteerings.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
