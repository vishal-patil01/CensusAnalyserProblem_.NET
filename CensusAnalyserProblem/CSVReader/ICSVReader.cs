
using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public interface ICSVDataReader
    {
        public Dictionary<string, IndianCensusDAO> GetCSVFileData(string headers,string csvFilePath);
    }
}
