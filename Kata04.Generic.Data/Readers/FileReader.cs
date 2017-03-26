using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kata04.Generic.Data.Readers
{
    public class FileReader<T> : IFileReader<T> where T : new()
    {
        public IEnumerable<T> GetAll(string pathToData, Func<string, T> processLine)
        {
            // todo implement caching maybe?
            // todo recoginize when file changes?
            var returnData = new List<T>();
            return File
                .ReadAllLines(pathToData)
                .Select(x => processLine(x))
                .Where(x => x != null);
        }
    }
}
