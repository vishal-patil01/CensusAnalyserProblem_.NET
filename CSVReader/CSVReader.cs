using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    class CSVReader :ICSVReader
    {
        string[] csvFileData;

        public string[] getCSVFileData(string headers, string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect File Format", CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            csvFileData = File.ReadAllLines(csvFilePath);
            if (csvFileData[0] != headers)
            {
                throw new CensusAnalyserException("Incorrect Headers", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string record in csvFileData.Skip(1))
            {
                if (!record.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return csvFileData.Skip(1).ToArray();
        }
    }
}
