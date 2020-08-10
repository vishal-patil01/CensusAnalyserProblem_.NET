using CensusAnalyser.model;
using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public class CensusAnalysers
    {
        ICSVDataReader csvDatareader = CSVFactory.createCSVReader();
        public List<IndianCensus> loadIndianCensusData(string headers,string csvFilePath)
        {
            List<IndianCensus> indianCensusList = csvDatareader.getCSVFileData<IndianCensus>(headers,csvFilePath);
            return indianCensusList;
        }

        public List<IndianStateCode> loadIndianStateData(string headers, string csvFilePath)
        {
            List<IndianStateCode> indianCensusList = csvDatareader.getCSVFileData<IndianStateCode>(headers, csvFilePath);
            return indianCensusList;
        }
    }
}
