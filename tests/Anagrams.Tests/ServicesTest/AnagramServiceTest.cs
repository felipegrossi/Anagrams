using ApplicationCore.Services;
using ApplicationCore.Services.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Anagrams.Tests.ServicesTest
{
    public class AnagramServiceTest
    {
        private readonly IAnagramService _anagramService;
        public AnagramServiceTest()
        {
            _anagramService = new AnagramService();
        }

        [Theory]
        [MemberData(nameof(GetAnagramsAsyncData))]
        public async void GetAnagramsAsync(bool assertValue, string inputValue, IEnumerable<string> anagrams)
        {
            if (assertValue)
                Assert.Equal(await _anagramService.GetAnagramsAsync(inputValue), anagrams);
            else
                Assert.NotEqual(await _anagramService.GetAnagramsAsync(inputValue), anagrams);
        }

        public static IEnumerable<object[]> GetAnagramsAsyncData =>
            new List<object[]>
            {
                //empty
                new object[]{true, ""       , new List<string>()},                                                      

                //no matches
                new object[]{true, "house"  , new List<string>()},                                                      
                
                //example from especs
                new object[]{true, "wolf"   , new List<string> { "flow", "fowl" } },
                
                //diff from specs
                new object[]{true, "test"   , new List<string> { "sett",  "stet" } },

                //case insensitive
                new object[]{true, "Inch"   , new List<string> { "chin" } },

                //with space in the end
                new object[]{true, "love "   , new List<string> { "vole" } },

                //with space in the begin
                new object[]{true, " study"   , new List<string> { "dusty" } },

                //between spaces
                new object[]{true, " night "   , new List<string> { "thing" } },

                //testing if the comparisson is working
                new object[]{false, "aaa"    , new List<string> { "bbb" } },
            };
    }
}