using ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnagramAPI.Controllers
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