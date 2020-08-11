using CensusAnalyserProblem;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser indiancensusAnalyser;
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
            indiancensusAnalyser = new CensusAnalyser();
        }
        //Indian Census Test
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            Assert.AreEqual(29, indianCensusRecord.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Test
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<string, IndianCensusDAO> indianStateCodeList = indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortType.SortBy.STATE_ASC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            Dictionary<string, IndianCensusDAO> indianCensusRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianCensusRecord, SortType.SortBy.STATE_ASC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.STATE_CODE_ASC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("AD", indianCensusSortedList[0].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianStateCodeHeader, indianStateCodeFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.STATE_CODE_ASC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("WB", indianCensusSortedList[indianCensusSortedList.Count - 1].stateCode);
        }
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.POPULATION_DESC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Uttar Pradesh", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousState()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.POPULATION_DESC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Sikkim", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.POPULATION_DENSITY_DESC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Bihar", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.POPULATION_DENSITY_DESC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Arunachal Pradesh", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.AREA_PER_SQM_DESC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Rajasthan", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<string, IndianCensusDAO> indianStateRecord = indiancensusAnalyser.LoadIndianCensusData(indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = indiancensusAnalyser.SortAndConvertCensusToJson(indianStateRecord, SortType.SortBy.AREA_PER_SQM_DESC);
            List<IndianCensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<IndianCensusDAO>>(sortedList);
            Assert.AreEqual("Goa", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }
    }
}