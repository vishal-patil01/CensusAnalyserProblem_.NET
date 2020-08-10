using CensusAnalyserProblem;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        readonly string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        readonly string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        readonly string indianCensusCsvFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
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
        public void GivenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            List<IndianCensus> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders,indianCensusCsvFile);
            Assert.AreEqual(29, indianCensusRecord.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>( () => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Test
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            List<IndianStateCode> indianStateCodeList = censusAnalyser.LoadIndianStateData(indianStateCodeHeader,indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.LoadIndianStateData(indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.LoadIndianStateData(indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.LoadIndianStateData(indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAnalyser.LoadIndianStateData(indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            List<IndianCensus> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortType.SortBy.STATE_ASC);
            List<IndianCensus> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            List<IndianCensus> indianCensusRecord = censusAnalyser.loadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortType.SortBy.STATE_ASC);
            List<IndianCensus> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensusSortedList[indianCensusSortedList.Count-1].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            List<IndianStateCode> indianStateRecord = censusAnalyser.LoadIndianStateData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAnalyser.SortAndConvertStateCodeDataToJson(indianStateRecord, SortType.SortBy.STATE_CODE_ASC);
            List<IndianStateCode> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianStateCode>>(sortedList);
            Assert.AreEqual("AD", indianCensusSortedList[0].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            List<IndianStateCode> indianStateRecord = censusAnalyser.LoadIndianStateData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAnalyser.SortAndConvertStateCodeDataToJson(indianStateRecord, SortType.SortBy.STATE_CODE_ASC);
            List<IndianStateCode> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianStateCode>>(sortedList);
            Assert.AreEqual("WB", indianCensusSortedList[indianCensusSortedList.Count-1].stateCode);
        }
    }
}