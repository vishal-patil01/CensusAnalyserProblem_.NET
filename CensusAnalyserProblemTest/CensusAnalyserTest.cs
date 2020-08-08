using CensusAnalyserProblem;
using NUnit.Framework;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        string csvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IndiaStateCensusData.csv";
        string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyser.cs";
        string WrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IncorrectDelimeters.csv";
        string WrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Data\IncorrectHeaders.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            string[] totalRecord = censusAnalyser.loadCSVData(csvFilePath);
            Assert.AreEqual(29, totalRecord.Length);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowException()
        {
            try 
            {
                censusAnalyser.loadCSVData(invalidCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadCSVData(nonCSVFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadCSVData(WrongDelemeterFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowException()
        {
            try
            {
                censusAnalyser.loadCSVData(WrongHeaderFile);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, e.type);
            }
        }
    }
}