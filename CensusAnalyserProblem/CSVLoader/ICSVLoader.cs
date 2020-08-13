// <copyright file="ICSVLoader.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System.Collections.Generic;

    /// <summary>
    ///  Description: Factory For Loading Census Data Based On Country Type.
    /// </summary>
    public interface ICSVLoader 
    {
        /// <summary>
        /// Description: Abstract Method To Load Census data From CSV File To Dictionary.
        /// </summary>
        /// <typeparam name="T"> Generic Type </typeparam>
        /// <param name="headers"> CSVFile Headers </param>
        /// <param name="csvFilePath"> CSVFile Path </param>
        /// <returns> Dictionary Of String As key And CensusDAO As Value </returns>
        public Dictionary<object, CensusDAO> LoadCensusData<T>(string headers, string csvFilePath);
    }
}