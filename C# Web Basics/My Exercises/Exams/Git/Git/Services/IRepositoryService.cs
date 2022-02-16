using Git.Models.Commits;
using Git.Models.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void CreateRepository(string name, string type, string ownerId);

        IEnumerable<RepositoryListingViewModel> GetAllPublicRepositories();

        CreateCommitRepositoryViewModel GetRepositoryById(string id);
    }
}
