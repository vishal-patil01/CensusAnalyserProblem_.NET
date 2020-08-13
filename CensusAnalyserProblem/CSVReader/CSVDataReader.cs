using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CSVDataReader : ICSVDataReader
    {
        public Dictionary<object, CensusDAO> ReadCSVFile<T>(string headers, string csvFilePath)
        {
            try
            {
                if (!File.Exists(csvFilePath))
                    throw new CSVFilesReaderException("File Not Found", CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND);
                if (Path.GetExtension(csvFilePath) != ".csv")
                    throw new CSVFilesReaderException("Incorrect File Format", CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT);
                string[] csvFileData = File.ReadAllLines(csvFilePath);
                if (csvFileData[0] != headers)
                    throw new CSVFilesReaderException("Incorrect Headers", CSVFilesReaderException.ExceptionType.INCORRECT_HEADER);
                foreach (string record in csvFileData.Skip(1))
                    if (!record.Contains(","))
                        throw new CSVFilesReaderException("File Contains Wrong Delimiter", CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER); using (var readers = new StreamReader(csvFilePath, Encoding.Default))
                using (var csv = new CsvReader(readers, System.Globalization.CultureInfo.CurrentCulture))
                    return csv.GetRecords<T>().ToList().ToDictionary(x => x.GetType().GetProperty("state").GetValue(x, null), x => CensusDAO.getDAO(x));
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message);
            }
        }
    }
}
