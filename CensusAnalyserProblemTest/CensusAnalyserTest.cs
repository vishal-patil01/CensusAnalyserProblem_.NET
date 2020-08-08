using CensusAnalyserProblem;
using NUnit.Framework;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        string csvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            censusAnalyser.loadCSVData(csvFilePath);
        }

        [Test]
        public void Test1()
        {
            int totalRecord = censusAnalyser.getTotalNumberOfRecords();
            Assert.AreEqual(29, totalRecord);
        }
    }
}