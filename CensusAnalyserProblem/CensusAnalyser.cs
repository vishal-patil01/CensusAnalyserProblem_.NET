using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();
        public Dictionary<string, IndianCensusDAO> loadIndianCensusData(string headers, string csvFilePath)
        {
           return csvDatareader.GetCSVFileData(headers, csvFilePath);
        }

        public string SortAndConvertCensusToJson(Dictionary<string, IndianCensusDAO> dictionary, SortBy sortType)
        {
            List<IndianCensusDAO> sortedList = SortType.SortIndianCensusData(dictionary.Select(x => x.Value).ToList(), sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}