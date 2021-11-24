using Anagrams.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Anagrams.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnagramsController : ControllerBase
    {
        private readonly IAnagramService _anagramService;

        public AnagramsController(IAnagramService anagramService)
        {
            _anagramService = anagramService;
        }

        [HttpGet(Name = "GetAnagrams")]
        public async Task<IEnumerable<string>> GetAsync(string WordToSearch)
        {
            return await _anagramService.GetAnagramsAsync(WordToSearch);
        }
    }
}