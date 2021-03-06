using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Contracts
{
    public interface IAddCollection
    {
        IReadOnlyCollection<string> Collection { get; }

        int Add(string item);
    }
}
