using System;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        string[] censusRecords;
        public void loadCSVData(string csvFilePath)
        {
            censusRecords = File.ReadAllLines(csvFilePath).Skip(1).ToArray();
        }

        public int getTotalNumberOfRecords()
        {
            return censusRecords.Length;
        }
    }
}
