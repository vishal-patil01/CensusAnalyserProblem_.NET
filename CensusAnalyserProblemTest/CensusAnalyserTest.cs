using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        readonly string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        readonly string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        readonly string csvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        readonly string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        readonly string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalyser.cs";
        readonly string wrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectDelimeters.csv";
        readonly string wrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        readonly string indianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        readonly string wrongIndianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        //Indian Census Test
        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            string[] indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Length);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CensusAnalyserException>( () => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Test
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            string[] indianStateCodeRecord = censusAnalyser.loadCSVFileData(indianStateCodeHeader,indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeRecord.Length);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, error.type);
        }
    }
}