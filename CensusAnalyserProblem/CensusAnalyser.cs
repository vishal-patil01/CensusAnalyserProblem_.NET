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
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            
            return File.ReadAllLines(csvFilePath).Skip(1).ToArray();
        }
    }
}
