using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System;

namespace CensusAnalyserProblem
{
    public class IndianCensusLoader
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();

        public Dictionary<object, CensusDAO> LoadIndianCensusData<T>(string headers, string csvFilePath)
        {
              return csvDatareader.ReadCSVFile<T>(headers, csvFilePath);
        }
    }
}