namespace MammasKitchen.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task SetVoteAsync(string productId, string userId, byte value);

        double GetAverageVotes(string id);
    }
}
