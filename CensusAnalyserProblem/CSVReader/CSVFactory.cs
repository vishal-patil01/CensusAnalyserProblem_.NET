// <copyright file="CSVFactory.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    /// <summary>
    ///  Description: Factory Class Returns Object CSV Reader.
    /// </summary>
    public class CSVFactory
    {
        /// <summary>
        /// Description: Returns Object CSV Reader.
        /// </summary>
        /// <returns>Instance Of ICSVDataReader</returns>
        public static ICSVReader CreateCSVReader()
        {
            return new CSVDataReader();
        }
    }
}
