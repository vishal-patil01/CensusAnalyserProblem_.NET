using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();
        public dynamic loadIndianCensusData(string headers,string csvFilePath)
        {
           return csvDatareader.GetCSVFileData<IndianCensus>(headers,csvFilePath).ToDictionary(x => x.state, x => x);
        }

        public Dictionary<string, IndianStateCode> LoadIndianStateData(string headers, string csvFilePath)
        {
            return csvDatareader.GetCSVFileData<IndianStateCode>(headers, csvFilePath).ToDictionary(x => x.state, x => x);
        }
        public string loadIndianStateCodeCensusData(string headers1,string headers2,string csvFilePath1, string csvFilePath2)
        {
            List<IndianCensus> censusList = csvDatareader.GetCSVFileData<IndianCensus>(headers1, csvFilePath1).OrderBy(c => c.state).ToList();
            List<IndianStateCode> stateCodeList = csvDatareader.GetCSVFileData<IndianStateCode>(headers2, csvFilePath2).OrderBy(c => c.state).ToList();
            var combineList = csvDatareader.GetCSVFileData<IndianStateCode>(headers2, csvFilePath2).OrderBy(c => c.state).ToList();
            combineList.Clear();
            foreach (IndianStateCode stateCodes in stateCodeList)
            {
                foreach (IndianCensus census in censusList)
                {
                    if (census.state==stateCodes.state)
                    {
                        combineList.Add(stateCodes);
                    }
                }
            }
            return JsonConvert.SerializeObject(combineList);

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
