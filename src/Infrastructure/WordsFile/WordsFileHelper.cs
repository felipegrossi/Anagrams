using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WordsFile
{
    public class WordsFileHelper
    {
        private static IEnumerable<string>? _words; //to create a list of cashed words and avoid accessing the source file on each interaction

        public static async Task<IEnumerable<string>> EnGetWordsAsync()
        {
            if (_words != null)
                return _words;

            var fileContent = await GetResourceContent("Infrastructure.WordsFile.En.txt");

            _words = fileContent.Split(Environment.NewLine)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s));

            return _words;
        }

        private static async Task<string> GetResourceContent(string filePath)
        {
            using (var s = typeof(WordsFileHelper).Assembly.GetManifestResourceStream(filePath))
            using (var reader = new StreamReader(s))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
