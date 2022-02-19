using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Data.Models;
using Git.Models.Commits;
using Git.Models.Repositories;

using static Git.Data.DataConstants;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext data;

        public RepositoryService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void CreateRepository(string name, string type, string ownerId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = type == RepositoryTypePublic,
                OwnerId = ownerId
            };

            this.data.Repositories.Add(repository);

            this.data.SaveChanges();
        }

        public IEnumerable<RepositoryListingViewModel> GetAllPublicRepositories()
            => this.data
                    .Repositories
                    .Where(r => r.IsPublic)
                    .Select(r => new RepositoryListingViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Owner = r.Owner.Username,
                        CreatedOn = r.CreatedOn.ToString(DateTimeFormat),
                        CommitsCount = r.Commits.Count
                    })
                    .ToList();

        public CreateCommitRepositoryViewModel GetRepositoryById(string id)
            => this.data
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new CreateCommitRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();                
    }
}
