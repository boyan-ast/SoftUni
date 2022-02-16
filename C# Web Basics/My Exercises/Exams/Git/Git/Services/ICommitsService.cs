using Git.Models.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void CreateCommit(string description, string creatorId, string repositoryId);

        IEnumerable<CommitListingViewModel> GetAll(string ownerId);

        void RemoveCommit(string commitId, string userId);
    }
}
