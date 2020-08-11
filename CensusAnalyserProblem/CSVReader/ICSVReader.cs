
using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public interface ICSVDataReader
    {
        public Dictionary<string, IndianCensusDAO> ReadIndianCensusData(string headers,string csvFilePath);
        public Dictionary<string, USCensus> ReadUsCensusData(string headers,string csvFilePath);
    }
}
