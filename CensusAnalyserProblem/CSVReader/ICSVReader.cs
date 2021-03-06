﻿// <copyright file="ICSVReader.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System.Collections.Generic;

    /// <summary>
    /// Description: Interface For CSV Factory Class.
    /// </summary>
    public interface ICSVReader
    {
        /// <summary>
        /// Description: Load Census data From CSV File And Return Dictionary Of String as Key And Census DAO as Value.
        /// </summary>
        /// <typeparam name="T"> Generic Type </typeparam>
        /// <param name="headers"> CSVFile Headers </param>
        /// <param name="csvFilePath"> CSVFile Path </param>
        /// <returns> Dictionary Of String As key And CensusDAO As Value </returns>
        public Dictionary<object, CensusDAO> ReadCSVFile<T>(string headers, string csvFilePath);
    }
}
