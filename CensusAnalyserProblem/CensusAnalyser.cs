using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static CensusAnalyserProblem.CSVReader;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        public string[] loadCSVFileData(string headers,string csvFilePath)
        {
            CSVReader csvDatareader = new CSVReader();
            ReadCSVFileData readCSVData = new ReadCSVFileData(csvDatareader.getCSVFileData);
            return readCSVData(headers, csvFilePath);
        }
    }
}
