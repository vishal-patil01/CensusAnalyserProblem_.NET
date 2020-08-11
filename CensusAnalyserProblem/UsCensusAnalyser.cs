using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class UsCensusAnalyser
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();

        public Dictionary<string, USCensus> LoadUsCensusData(string headers, string csvFilePath)
        {
            return csvDatareader.ReadUsCensusData(headers, csvFilePath);
        }
    }
}