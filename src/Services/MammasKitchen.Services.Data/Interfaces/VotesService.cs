namespace MammasKitchen.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MammasKitchen.Data.Common.Repositories;
    using MammasKitchen.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(string id)
        {
            return this.votesRepository.All()
                .Where(x => x.ProductId == id)
                .Average(x => x.Value);
        }

        public async Task SetVoteAsync(string productId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);
            if (vote == null)
            {
                vote = new Vote
                {
                    ProductId = productId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }

    }
}
