using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.Core.Services.Interfaces
{
    public interface IAnagramService
    {
        public Task<IEnumerable<string>> GetAnagramsAsync(string word);
    }
}
