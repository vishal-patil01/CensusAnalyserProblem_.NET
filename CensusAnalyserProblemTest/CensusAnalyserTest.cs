// <copyright file="CensusAnalyserTest.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblemTest
{
    using System.Collections.Generic;
    using CensusAnalyserProblem;
    using NUnit.Framework;
    using Newtonsoft.Json;
    using static CensusAnalyserProblem.CensusEnums;

    /// <summary>
    /// Description: Test Class For Testing CensusAnalyzer Project.
    /// </summary>
    public class CensusAnalyserTest
    {
        private readonly string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        private readonly string indianStateCodeHeader = "SrNo,State Name,TIN,StateCode";
        private readonly string unitedStatesCensusDataHeader = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        private readonly string indianCensusCsvFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        private readonly string invalidCsvFilePath = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\IndiaStateCensusData.csv";
        private readonly string unitedStatesCensusCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\USCensusData.csv";
        private readonly string nonCSVFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblem\CSVReader\CSVDataReader.cs";
        private readonly string wrongDelemeterFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectDelimeters.csv";
        private readonly string wrongHeaderFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IncorrectHeaders.csv";
        private readonly string indianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCode.csv";
        private readonly string wrongIndianStateCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\InCorrectIndiaStateCode.csv";
        private readonly string wrongDelimeterUsCodeFile = @"D:\vishal\Projects\.Net\Console App\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\WrongDelimeterUSCensusData.csv";

        /// <summary>
        /// Instance Variable Of CensusAnalyzerAdapter
        /// </summary>
        private CensusAnalyserAdapter censusAdapter;

        /// <summary>
        /// Setup Method To Initialize Instance Of CensusAnalyzerAdapter.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.censusAdapter = new CensusAnalyserAdapter();
        }

        /// <summary>
        /// Test To check Total Number Of Record In Indian CSV File.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            var indianCensunitedStatesRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            Assert.AreEqual(29, indianCensunitedStatesRecord.Count);
        }

        /// <summary>
        /// Test To Check File Not Found Exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.FILE_NOT_FOUND, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Format Exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_FILE_FORMAT, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Incorrect Delimeter Exception
        /// </summary>
        [Test]

        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.wrongDelemeterFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_DELIMITER, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Header Exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_HEADER, error.ExceptionType);
        }

        /// <summary>
        /// Test To check Total Number Of Record In Indian State Code CSV File.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            var indianStateCodeList = this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.indianStateCodeFile);
            Assert.AreEqual(37, indianStateCodeList.Count);
        }

        /// <summary>
        /// Test To Check File Not Found Exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.FILE_NOT_FOUND, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Format Exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_FILE_FORMAT, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Incorrect Delimeter Exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.wrongIndianStateCodeFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_DELIMITER, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Header Exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.wrongHeaderFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_HEADER, error.ExceptionType);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File Alphabatically
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            var indianCensunitedStatesRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianCensunitedStatesRecord, SortBy.STATE, SortOrder.ASCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Andhra Pradesh", indianCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File Alphabatically
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            var indianCensunitedStatesRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianCensunitedStatesRecord, SortBy.STATE, SortOrder.ASCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("West Bengal", indianCensunitedStateSortedList[indianCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To get Sorted Indian State Code CSV File Alphabatically
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsFirstStateAsAndhraPradesh()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.indianStateCodeFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.STATE_CODE, SortOrder.ASCENDING);
            List<IndianStateCode> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianStateCode>>(sortedList);
            Assert.AreEqual("AD", indianCensunitedStateSortedList[0].StateCode);
        }

        /// <summary>
        /// Test To get Sorted Indian State Code CSV File Alphabatically
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLastStateWestBengal()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianStateCode>(Country.INDIA, DTO.INDIA_STATE_CODE, this.indianStateCodeHeader, this.indianStateCodeFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.STATE_CODE, SortOrder.ASCENDING);
            List<IndianStateCode> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianStateCode>>(sortedList);
            Assert.AreEqual("WB", indianCensunitedStateSortedList[indianCensunitedStateSortedList.Count - 1].StateCode);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File On Population
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.POPULATION, SortOrder.DESCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Uttar Pradesh", indianCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File On Population
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousState()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.POPULATION, SortOrder.DESCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Sikkim", indianCensunitedStateSortedList[indianCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File On DensityPerSQKm
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnDensityPerSqm()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.DENSITY_PER_SQ_KM, SortOrder.DESCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Bihar", indianCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File On DensityPerSQKm
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnDensityPerSqm()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.DENSITY_PER_SQ_KM, SortOrder.DESCENDING);
            //List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            //  Assert.AreEqual("Arunachal Pradesh", indianCensunitedStateSortedList[indianCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File On AreaPerSQKm
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnAreaPerSqm()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Rajasthan", indianCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted Indian Census CSV File On AreaPerSQKm
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnAreaPerSqm()
        {
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.AREA_IN_SQ_KM, SortOrder.DESCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("Goa", indianCensunitedStateSortedList[indianCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To check Total Number Of Record In UnitedState CSV File.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            var indianCensunitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            Assert.AreEqual(51, indianCensunitedStatesRecord.Count);
        }

        /// <summary>
        /// Test To Check File Not Found Exception
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.invalidCsvFilePath));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.FILE_NOT_FOUND, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Format Exception
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFile_WhenFileFormatIsIncorrect_ShouldThrowIncorrectFileFormatException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.nonCSVFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_FILE_FORMAT, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Incorrect Delimeter Exception
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFile_WhenFileFormatIsCorrectButDelimeterIsWrong_ShouldThrowIncorrectDelimeterException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.wrongDelimeterUsCodeFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_DELIMITER, error.ExceptionType);
        }

        /// <summary>
        /// Test To Check File Header Exception
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFile_WhenFileFormatIsCorrectButHeaderIsIncorrect_ShouldThrowIncorrectHeaderException()
        {
            var error = Assert.Throws<CSVFilesReaderException>(() => this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.indianCensusCsvFile));
            Assert.AreEqual(CSVFilesReaderException.CSVReaderExceptionType.INCORRECT_HEADER, error.ExceptionType);
        }

        /// <summary>
        /// Test To get Sorted United State Census CSV File On Population
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.POPULATION, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("California", unitedStateCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted United State Census CSV File On Population
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousState()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.POPULATION, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("Wyoming", unitedStateCensunitedStateSortedList[unitedStateCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To get Sorted United State Census CSV File On PopulationDensity
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnPopulationDensity()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("District of Columbia", unitedStateCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted United State Census CSV File On PopulationDensity
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnPopulationDensity()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("Alaska", unitedStateCensunitedStateSortedList[unitedStateCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To get Sorted United State Census CSV File On Populouation And State Area
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsMostPopulousStateBasedOnArea()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.TOTAL_AREA, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("Alaska", unitedStateCensunitedStateSortedList[0].State);
        }

        /// <summary>
        /// Test To get Sorted United State Census CSV File On Population And State Area
        /// </summary>
        [Test]
        public void GivenUsCensusCSVFileForSorting_WhenFileExist_ShouldReturnsLeastPopulousStateBasedOnArea()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.TOTAL_AREA, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(sortedList);
            Assert.AreEqual("District of Columbia", unitedStateCensunitedStateSortedList[unitedStateCensunitedStateSortedList.Count - 1].State);
        }

        /// <summary>
        /// Test To get Most Populous State Among Indian Census CSV File And United State Census File.
        /// </summary>
        [Test]
        public void GivenUsCensusAndIndianCensusCSVFile_WhenFileExist_ShouldReturnsMostPopulousState()
        {
            var unitedStatesRecord = this.censusAdapter.LoadCensusData<USCensus>(Country.US, DTO.US, this.unitedStatesCensusDataHeader, this.unitedStatesCensusCSVFile);
            string unitedStateSortedList = this.censusAdapter.SortAndConvertCensusToJSON(unitedStatesRecord, SortBy.POPULATION_DENSITY, SortOrder.DESCENDING);
            List<USCensus> unitedStateCensunitedStateSortedList = JsonConvert.DeserializeObject<List<USCensus>>(unitedStateSortedList);
            var indianStateRecord = this.censusAdapter.LoadCensusData<IndianCensus>(Country.INDIA, DTO.INDIA_CENSUS, this.indianCensusDataHeaders, this.indianCensusCsvFile);
            string sortedList = this.censusAdapter.SortAndConvertCensusToJSON(indianStateRecord, SortBy.DENSITY_PER_SQ_KM, SortOrder.DESCENDING);
            List<IndianCensus> indianCensunitedStateSortedList = JsonConvert.DeserializeObject<List<IndianCensus>>(sortedList);
            Assert.AreEqual("District of Columbia", this.censusAdapter.GetMostPopulousState(indianCensunitedStateSortedList[0], unitedStateCensunitedStateSortedList[0]));
        }
    }
}