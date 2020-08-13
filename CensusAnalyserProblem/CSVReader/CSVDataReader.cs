// <copyright file="CSVDataReader.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using CsvHelper;

    /// <summary>
    ///  Description: Read CSV File And Convert Data To Dictionary.
    /// </summary>
    public class CSVDataReader : ICSVReader
    {
        /// <summary>
        /// Description: Load Census data From CSV File And Return Dictionary Of String as Key And Census DAO as Value.
        /// </summary>
        /// <typeparam name="T"> Generic Type </typeparam>
        /// <param name="headers"> CSVFile Headers </param>
        /// <param name="csvFilePath"> CSVFile Path </param>
        /// <returns> Dictionary Of String As key And CensusDAO As Value </returns>
        public Dictionary<object, CensusDAO> ReadCSVFile<T>(string headers, string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CSVFilesReaderException("File Not Found", CSVFilesReaderException.CSVReaderExceptionType.FILE_NOT_FOUND);
            }

            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CSVFilesReaderException("Incorrect File Format", CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_FILE_FORMAT);
            }

            string[] csvFileData = File.ReadAllLines(csvFilePath);
            if (csvFileData[0] != headers)
            {
                throw new CSVFilesReaderException("Incorrect Headers", CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_HEADER);
            }

            foreach (string record in csvFileData.Skip(1))
            {
                if (!record.Contains(","))
                {
                    throw new CSVFilesReaderException("File Contains Wrong Delimiter", CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_DELIMITER);
                }
            }

            using (var readers = new StreamReader(csvFilePath, Encoding.Default))
            using (var csv = new CsvReader(readers, System.Globalization.CultureInfo.CurrentCulture))
            {
                return csv.GetRecords<T>().ToList().ToDictionary(x => x.GetType().GetProperty("State").GetValue(x, null), x => CensusDAO.GetDAO(x));
            }
        }
    }
}
