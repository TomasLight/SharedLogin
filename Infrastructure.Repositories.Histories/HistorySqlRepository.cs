﻿namespace Infrastructure.Repositories.Histories
{
    using Infrastructure.DbContexts;
    using Infrastructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HistorySqlRepository : IHistoryRepository
	{
		private readonly SqlDbContext dbContext;

		public HistorySqlRepository(SqlDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Task<History> FindByIdAcync(int id)
		{
			return dbContext.Histories.AsNoTracking()
					.FirstOrDefaultAsync(history => history.Id == id);
		}

		public Task<List<History>> FindByAccountIdAsync(int accountId)
		{
			return dbContext.Histories.AsNoTracking()
					.Where(history => history.AccountId == accountId)
					.ToListAsync();
		}

		public async Task<History> AddAsync(History history)
		{
			await dbContext.Histories.AddAsync(history);
			await dbContext.SaveChangesAsync();
			return history;
		}

		public async Task<History> UpdateAsync(History history)
		{
			dbContext.Histories.Update(history);
			await dbContext.SaveChangesAsync();
			return history;
		}
	}
}