
using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public interface ICSVDataReader
    {
       // public delegate string[] ReadCSVFileData(string headers, string csvFilePath);
       // public string[] getCSVFileData(string headers, string csvFilePath);

public delegate List<T> ReadCSVFileData<T>(string csvFilePath);
        public List<T> getCSVFileData<T>(string headers,string csvFilePath);
    }
}
