// <copyright file="IndianCensusLoader.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System.Collections.Generic;

    /// <summary>
    ///  Description: Load Indian Census data From CSV File To Dictionary.
    /// </summary>
    public class IndianCensusLoader : ICSVLoader
    {
        /// <summary>
        ///  Description: Instance Of CSVFileReader Class
        /// </summary>
        private readonly ICSVReader csvDatareader = CSVFactory.CreateCSVReader();

        /// <summary>
        /// Description: Load Indian Census data From CSV File To Dictionary.
        /// </summary>
        /// <typeparam name="T"> Generic Type </typeparam>
        /// <param name="headers"> CSVFile Headers </param>
        /// <param name="csvFilePath"> CSVFile Path </param>
        /// <returns> Dictionary Of String As key And CensusDAO As Value </returns>
        public Dictionary<object, CensusDAO> LoadCensusData<T>(string headers, string csvFilePath)
        {
            return this.csvDatareader.ReadCSVFile<T>(headers, csvFilePath);
        }
    }
}