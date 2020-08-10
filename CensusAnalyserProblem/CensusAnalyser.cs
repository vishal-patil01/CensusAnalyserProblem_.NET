using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();
        public List<IndianCensus> loadIndianCensusData(string headers,string csvFilePath)
        {
           return csvDatareader.GetCSVFileData<IndianCensus>(headers,csvFilePath);
        }

        public List<IndianStateCode> LoadIndianStateData(string headers, string csvFilePath)
        {
            return csvDatareader.GetCSVFileData<IndianStateCode>(headers, csvFilePath);
        }

        public string SortAndConvertCensusToJson(List<IndianCensus> list,SortBy sortType)
        {
            List<IndianCensus> sortedList = SortCensusData(list, sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
        public string SortAndConvertStateCodeDataToJson(List<IndianStateCode> list, SortBy sortType)
        {
            List<IndianStateCode> sortedList = SortType.SortStateCodeData(list, sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}
