using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CSVDataReader : ICSVDataReader
    {
        public Dictionary<string,IndianCensusDAO> ReadIndianCensusData(string headers,string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CSVFilesReaderException("File Not Found", CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CSVFilesReaderException("Incorrect File Format", CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            string[] csvFileData = File.ReadAllLines(csvFilePath);
            if (csvFileData[0] != headers)
            {
                throw new CSVFilesReaderException("Incorrect Headers", CSVFilesReaderException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string record in csvFileData.Skip(1))
            {
                if (!record.Contains(","))
                {
                    throw new CSVFilesReaderException("File Contains Wrong Delimiter", CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            try
            {
                using (var readers = new StreamReader(csvFilePath, Encoding.Default))
                using (var csv = new CsvReader(readers, System.Globalization.CultureInfo.CurrentCulture))
                {
                    if (headers.Contains("State,Population,AreaInSqKm,DensityPerSqKm"))
                    {
                        IndianCensus[] indianCensus = csv.GetRecords<IndianCensus>().ToArray();
                        return indianCensus.ToDictionary(x => x.state, x => new IndianCensusDAO(x));
                    }
                    IndianStateCode[] indianStateCodes = csv.GetRecords<IndianStateCode>().ToArray();
                    return indianStateCodes.ToDictionary(x => x.state, x => new IndianCensusDAO(x));
                }

            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
        }
        public Dictionary<string, USCensus> ReadUsCensusData(string headers, string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CSVFilesReaderException("File Not Found", CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CSVFilesReaderException("Incorrect File Format", CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT);
            }
            string[] csvFileData = File.ReadAllLines(csvFilePath);
            if (csvFileData[0] != headers)
            {
                throw new CSVFilesReaderException("Incorrect Headers", CSVFilesReaderException.ExceptionType.INCORRECT_HEADER);
            }
            foreach (string record in csvFileData.Skip(1))
            {
                if (!record.Contains(","))
                {
                    throw new CSVFilesReaderException("File Contains Wrong Delimiter", CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER);
                }
            }
            try
            {
                using (var readers = new StreamReader(csvFilePath, Encoding.Default))
                using (var csv = new CsvReader(readers, System.Globalization.CultureInfo.CurrentCulture))
                {
                   return csv.GetRecords<USCensus>().ToArray().ToDictionary(x => x.state, x=> x);
                }

            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
