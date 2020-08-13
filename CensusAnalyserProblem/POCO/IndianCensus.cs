// <copyright file="IndianCensus.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System;
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// Description: POCO Class Mapped With Indian Census CSVFile .
    /// </summary>
    public class IndianCensus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensus"/> class.
        /// </summary>
        public IndianCensus() 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensus"/> class.
        /// </summary>
        /// <param name="state">State Name</param>
        /// <param name="population">State Population</param>
        /// <param name="areaInSqKm">State Area</param>
        /// <param name="densityPerSqKm">State Population Density</param>
        public IndianCensus(string state, int population, float areaInSqKm, float densityPerSqKm)
        {
            this.State = state;
            this.Population = population;
            this.AreaInSqKm = Convert.ToInt32(areaInSqKm);
            this.DensityPerSqKm = Convert.ToInt32(densityPerSqKm);
        }

        [Name("State")]
        public string State { get; set; }

        [Name("Population")]
        public int Population { get; set; }

        [Name("AreaInSqKm")]
        public int AreaInSqKm { get; set; }

        [Name("DensityPerSqKm")]
        public int DensityPerSqKm { get; set; }
    }
}
