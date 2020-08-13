using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class UsCensusLoader
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();

        public Dictionary<object,CensusDAO> LoadUsCensusData<T>(string headers, string csvFilePath)
        {
            return csvDatareader.ReadCSVFile<T>(headers, csvFilePath);
        }
    }
}