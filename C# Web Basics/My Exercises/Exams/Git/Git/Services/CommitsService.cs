using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Models.Commits;

using static Git.Data.DataConstants;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext data;

        public CommitsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void CreateCommit(string description, string creatorId, string repositoryId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = creatorId,
                RepositoryId = repositoryId
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();
        }

        public IEnumerable<CommitListingViewModel> GetAll(string ownerId)
            => this.data
                .Commits
                .Where(c => c.CreatorId == ownerId)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    Repository = c.Repository.Name,
                    CreatedOn = c.CreatedOn.ToString(DateTimeFormat)
                });

        public void RemoveCommit(string commitId, string userId)
        {
            var commit = this.data.Commits.Find(commitId);

            if (commit.CreatorId == userId)
            {
                this.data.Remove(commit);
                this.data.SaveChanges();
            }
        }
    }
}
