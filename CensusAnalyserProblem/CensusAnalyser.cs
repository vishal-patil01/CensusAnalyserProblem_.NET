using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();
        public Dictionary<string, IndianCensus> loadIndianCensusData(string headers,string csvFilePath)
        {
           return csvDatareader.GetCSVFileData<IndianCensus>(headers,csvFilePath).ToDictionary(x => x.state, x => x);
        }

        public Dictionary<string, IndianStateCode> LoadIndianStateData(string headers, string csvFilePath)
        {
            return csvDatareader.GetCSVFileData<IndianStateCode>(headers, csvFilePath).ToDictionary(x => x.state, x => x);
        }

        public string SortAndConvertCensusToJson(Dictionary<string, IndianCensus> dictionary, SortBy sortType)
        {
            List<IndianCensus> sortedList = SortType.SortIndianCensusData(dictionary.Select(x => x.Value).ToList(), sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
        public string SortAndConvertStateCodeDataToJson(Dictionary<string, IndianStateCode> dictionary, SortBy sortType)
        {
            List<IndianStateCode> sortedList = SortType.SortStateCodeData(dictionary.Select(x => x.Value).ToList(), sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}
