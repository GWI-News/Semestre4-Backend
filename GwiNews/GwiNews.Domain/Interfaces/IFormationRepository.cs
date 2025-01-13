using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IFormationRepository
    {
        public Task<IEnumerable<Formation>> GetFormations();
        public Task<Formation> GetFormation(Guid id);
        public Task<IEnumerable<Formation>> GetActiveFormations();
        public Task<IEnumerable<Formation>> GetFormationsByUserId(Guid userId);
        public Task<Formation> CreateFormation(Formation formation);
        public Task<Formation> UpdateFormation(Formation formation);
        public Task<IEnumerable<Formation>> DeleteFormation(Formation formation);
    }
}
