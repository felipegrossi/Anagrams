using ApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class AnagramService : IAnagramService
    {
        public async Task<IEnumerable<string>> GetAnagramsAsync(string inputWord)
        {
            inputWord = inputWord.Trim().ToLower();

            var enWords = await Infrastructure.WordsFile.WordsFileHelper.EnGetWordsAsync();

            return enWords
                .Where(s => s.Length == inputWord.Length) //same size
                .Where(s => s.ToLower().OrderBy(c => c).SequenceEqual(inputWord.OrderBy(i => i))) //same chars
                .Where(s => s != inputWord); //not the same word
        }
    }
}
