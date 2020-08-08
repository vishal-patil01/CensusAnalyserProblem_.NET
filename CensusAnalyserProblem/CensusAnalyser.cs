using System;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        string[] censusRecords;
        public string[] loadCSVData(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.CENSUS_FILE_Not_Found);
            }
            return File.ReadAllLines(csvFilePath).Skip(1).ToArray();
        }
    }
}
