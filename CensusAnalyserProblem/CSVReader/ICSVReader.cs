
using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public interface ICSVDataReader
    {
        public Dictionary<object, CensusDAO> ReadCSVFile<T>(string headers, string csvFilePath);
    }
}
