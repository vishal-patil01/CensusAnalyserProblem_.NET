using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        ICSVDataReader csvDatareader = CSVFactory.CreateCSVReader();
        public List<IndianCensus> loadIndianCensusData(string headers,string csvFilePath)
        {
            List<IndianCensus> indianCensusList = csvDatareader.GetCSVFileData<IndianCensus>(headers,csvFilePath);
            return indianCensusList;
        }

        public List<IndianStateCode> LoadIndianStateData(string headers, string csvFilePath)
        {
            List<IndianStateCode> indianCensusList = csvDatareader.GetCSVFileData<IndianStateCode>(headers, csvFilePath);
            return indianCensusList;
        }

        public string SortAndConvertDataToJson(List<IndianCensus> list)
        {
            list.Sort((x, y) => x.state.CompareTo(y.state));
            string jsonObject = JsonConvert.SerializeObject(list);
            return jsonObject;
        }
    }
}
