using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        string[] censusRecords;
        public string[] loadIndianCensusData(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect File Format", CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            censusRecords = File.ReadAllLines(csvFilePath);
            if (censusRecords[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
            {
                throw new CensusAnalyserException("Incorrect Headers", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string record in censusRecords)
            {
                if (!record.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            return censusRecords.Skip(1).ToArray();
        }
        public IEnumerable<string> loadIndianStateCodeData(string csvFilePath)
        {
            foreach (var items in File.ReadAllLines(csvFilePath).Skip(1))
            {
                yield return items.ToString();
            }
        }
    }
}
