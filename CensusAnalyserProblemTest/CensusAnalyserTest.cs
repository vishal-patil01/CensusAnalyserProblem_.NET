using CensusAnalyserProblem;
using System.Collections.Generic;
using CensusAnalyser.model;
using NUnit.Framework;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalysers censusAnalyser;
        readonly string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        readonly string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        readonly string csvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        readonly string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        readonly string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CensusAnalysers.cs";
        readonly string wrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectDelimeters.csv";
        readonly string wrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        readonly string indianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        readonly string wrongIndianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalysers();
        }
        //Indian Census Test
        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            List<IndianCensus> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders,csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Count);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>( () => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void givenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Test
        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            List<IndianStateCode> indianStateCodeList = censusAnalyser.loadIndianStateData(indianStateCodeHeader,indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianStateData(indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianStateData(indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianStateData(indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void givenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianStateData(indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }
    }
}