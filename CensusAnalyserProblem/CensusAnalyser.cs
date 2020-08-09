using static CensusAnalyserProblem.ICSVReader;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        public string[] loadCSVFileData(string headers,string csvFilePath)
        {
            ICSVReader csvDatareader = CSVFactory.createCSVReader();
            ReadCSVFileData readCSVData = new ReadCSVFileData(csvDatareader.getCSVFileData);
            return readCSVData(headers, csvFilePath);
        }
    }
}
