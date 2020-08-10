
using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public interface ICSVDataReader
    {
        public List<T> GetCSVFileData<T>(string headers,string csvFilePath);
    }
}
