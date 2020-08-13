using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static CensusAnalyserProblem.SortType;

namespace CensusAnalyserProblem
{
    public abstract class CensusAnalyserAdapter
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public abstract Dictionary<object, CensusDAO> LoadCensusData<T>(Country country,string headers, string csvFilePath);
        public string SortAndConvertCensusToJson(Dictionary<object, CensusDAO> dictionary,DTO dto, SortBy sortType, SortOrder sortOrder)
        {
            string sortFieldTitleCase = textInfo.ToTitleCase(sortType.ToString().ToLower()).Replace("_", string.Empty);
            string sortField = Char.ToLowerInvariant(sortFieldTitleCase[0]) + sortFieldTitleCase.Substring(1);
            var sortedList = SortType.SortCensusData(dictionary.Select(x => x.Value).ToList(), sortField, sortOrder).Select(x => x.getDTO(dto, x)).ToList();
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}
