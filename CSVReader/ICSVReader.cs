
namespace CensusAnalyserProblem
{
    interface ICSVReader
    {
        public delegate string[] ReadCSVFileData(string headers, string csvFilePath);
        public string[] getCSVFileData(string headers, string csvFilePath);
    }
}
