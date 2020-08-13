// <copyright file="CensusAnalyserAdapter.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Newtonsoft.Json;
    using static CensusAnalyserProblem.CensusEnums;

    public class CensusAnalyserAdapter
    {
        /// <summary>
        /// Description: Instance Of TextInfo For Define And Modify Text Properties
        /// </summary>
        private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        /// <summary>
        /// Description: Loading Census Data From CSV File Based On Country
        /// </summary>
        /// <typeparam name="T">Generic Class Type</typeparam>
        /// <param name="country">Enumerator For Specifying Country</param>
        /// <param name="dto">Enumerator Type For Country Specific DTO</param>
        /// <param name="headers">Header String For CSV File</param>
        /// <param name="csvFilePath">CSV File Path</param>
        /// <returns>Dictionary Of CSV Data</returns>
        public Dictionary<object, dynamic> LoadCensusData<T>(Country country, DTO dto, string headers, string csvFilePath)
        {
            ICSVLoader csvLoader = CensusLoaderFactory.GetInstance(country);
            Dictionary<object, CensusDAO> dictionary = csvLoader.LoadCensusData<T>(headers, csvFilePath);
            return dictionary.Select(key => key.Value.GetDTO(dto, key.Value)).ToList().ToDictionary(value => value.GetType().GetProperty("State").GetValue(value), value => value);
        }

        /// <summary>
        ///  Description: Sort Dictionary On Sort Field And Convert Data Into JSON.
        /// </summary>
        /// <param name="dictionary">Dictionary Of CSV Data</param>
        /// <param name="sortType">Enumerator Value For specifying Sort Field</param>
        /// <param name="sortOrder">Enumerator Value For specifying Sort Order</param>
        /// <returns>Sorted List In JSON String</returns>
        public string SortAndConvertCensusToJSON(Dictionary<object, dynamic> dictionary, SortBy sortType, SortOrder sortOrder)
        {
            string sortField = this.textInfo.ToTitleCase(sortType.ToString().ToLower()).Replace("_", string.Empty);
            var sortedList = this.SortData(dictionary.Select(value => value.Value).ToList(), sortField, sortOrder);
            return JsonConvert.SerializeObject(sortedList);
        }

        /// <summary>
        ///  Description: Return Most Populous State Among Two.
        /// </summary>
        /// <param name="indianCensus">Instance Of IndianCensus POCO</param>
        /// <param name="unitedStateCensus">Instance Of USCensus POCO</param>
        /// <returns>State Name</returns>
        public string GetMostPopulousState(IndianCensus indianCensus, USCensus unitedStateCensus)
        {
            return indianCensus.DensityPerSqKm > unitedStateCensus.PopulationDensity ? indianCensus.State : unitedStateCensus.State;
        }

        /// <summary>
        /// Description: Sort Dictionary On Sort Field And Convert Data Into JSON.
        /// </summary>
        /// <param name="list">List Containing CSV Data</param>
        /// <param name="sortType">Enumerator Value For specifying Sort Field</param>
        /// <param name="sortOrder">Enumerator Value For specifying Sort Order</param>
        /// <returns>Sorted List</returns>
        public List<dynamic> SortData(List<dynamic> list, string sortType, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.ASCENDING ? list.OrderBy(value => value.GetType().GetProperty(sortType).GetValue(value)).ToList()
                  : list.OrderByDescending(value => value.GetType().GetProperty(sortType).GetValue(value)).ToList();
        }
    }
}