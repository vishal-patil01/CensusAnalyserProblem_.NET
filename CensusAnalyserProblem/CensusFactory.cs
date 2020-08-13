using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System;
using static CensusAnalyserProblem.CensusEnums;

namespace CensusAnalyserProblem
{
    public class CensusFactory : CensusAnalyserAdapter
    {
        public override Dictionary<object, CensusDAO> LoadCensusData<T>(Country country, string headers, string csvFilePath)
        {
            if (country == Country.INDIA)
                return new IndianCensusLoader().LoadIndianCensusData<T>(headers, csvFilePath);
            return new UsCensusLoader().LoadUsCensusData<T>(headers, csvFilePath);
        }
    }
}