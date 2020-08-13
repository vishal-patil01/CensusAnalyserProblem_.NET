using CensusAnalyserProblem;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using static CensusAnalyserProblem.SortType;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusFactory indiancensusAnalyser;
        UsCensusLoader usCensusAnalyser;
        CensusAnalyserAdapter censusAdapter;
        readonly string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        readonly string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        readonly string usCensusDataHeader = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        readonly string indianCensusCsvFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        readonly string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        readonly string usCensusCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.csv";
        readonly string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CSVReader\CSVDataReader.cs";
        readonly string wrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectDelimeters.csv";
        readonly string wrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        readonly string indianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        readonly string wrongIndianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";
        readonly string wrongDelimeterUsCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\WrongDelimeterUSCensusData.csv";

        [SetUp]
        public void Setup()
        {
            indiancensusAnalyser = new CensusFactory();
            usCensusAnalyser = new UsCensusLoader();
            censusAdapter = new CensusFactory();

        }
        //Indian Census Test
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA,indianCensusDataHeaders, indianCensusCsvFile);
            Assert.AreEqual(29, indianCensusRecord.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA,indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, wrongDelemeterFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }

        //Indian StateCode Test
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<object, CensusDAO> indianStateCodeList = censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, wrongIndianStateCodeFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA,indianStateCodeHeader, wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }
        //Sorting Test
        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianCensusRecord,SortBy.STATE,SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianCensusRecord, SortBy.STATE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.STATE_CODE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("AD", indianCensusSortedList[0].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, indianStateCodeHeader, indianStateCodeFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.STATE_CODE, SortOrder.ASCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("WB", indianCensusSortedList[indianCensusSortedList.Count - 1].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.POPULATION, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Uttar Pradesh", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousState()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.POPULATION, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Sikkim", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Bihar", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnDensityPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Arunachal Pradesh", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA,indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Rajasthan", indianCensusSortedList[0].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnAreaPerSqm()
        {
            Dictionary<object, CensusDAO> indianStateRecord = censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA,indianCensusDataHeaders, indianCensusCsvFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(indianStateRecord,SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<CensusDAO> indianCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Goa", indianCensusSortedList[indianCensusSortedList.Count - 1].state);
        }
        //US Census Test
        [Test]
        public void GivenUsCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            Dictionary<object, CensusDAO> indianCensusRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeader, usCensusCSVFile);
            Assert.AreEqual(51, indianCensusRecord.Count);
        }

        [Test]
        public void GivenUsCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US,usCensusDataHeader, invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.FILE_NOT_FOUND, error.type);
        }

        [Test]
        public void GivenUsCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeader, nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_FILE_FORMAT, error.type);
        }

        [Test]
        public void GivenUsCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeader, wrongDelimeterUsCodeFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_DELIMITER, error.type);
        }

        [Test]
        public void GivenUsCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeader, indianCensusCsvFile));
            Assert.AreEqual(CSVFilesReaderException.ExceptionType.INCORRECT_HEADER, error.type);
        }
        //UsCensus Sorting Test
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeader, usCensusCSVFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, SortBy.POPULATION, SortOrder.DESCENDING);
            List<CensusDAO> usCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("California", usCensusSortedList[0].state);
        }

        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousState()
        {
            Dictionary<object, CensusDAO> usRecord = censusAdapter.LoadCensusData<USCensus>(Country.US, usCensusDataHeader, usCensusCSVFile);
            string sortedList = censusAdapter.SortAndConvertCensusToJson(usRecord, SortBy.POPULATION, SortOrder.DESCENDING);
            List<CensusDAO> usCensusSortedList = JsonConvert.DeserializeObject<List<CensusDAO>>(sortedList);
            Assert.AreEqual("Wyoming", usCensusSortedList[usCensusSortedList.Count - 1].state);
        }

    }
}