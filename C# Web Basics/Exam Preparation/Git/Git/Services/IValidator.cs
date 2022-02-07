using System.Collections.Generic;

using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterFormModel model);

        ICollection<string> ValidateRepository(CreateRepositoryFormModel model);

        ICollection<string> ValidateCommit(CommitFormModel model);
    }
}
