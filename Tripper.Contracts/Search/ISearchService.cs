using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripper.Contracts.Search
{
    public interface ISearchService
    {
        Task<T> GetFromUrl<T>(string partialUrl) where T : class;
    }
}
