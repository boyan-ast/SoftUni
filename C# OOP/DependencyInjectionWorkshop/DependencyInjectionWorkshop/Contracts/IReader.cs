using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWorkshop.Contracts
{
    public interface IReader
    {
        string ReadKey();

        string ReadLine();
    }
}
