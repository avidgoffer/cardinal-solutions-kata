using System;
using System.Collections.Generic;

namespace Kata04.Generic.Data.Readers
{
    public interface IFileReader<T>
    {
        IEnumerable<T> GetAll(string pathToData, Func<string, T> processLine);
    }
}