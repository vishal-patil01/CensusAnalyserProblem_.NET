// <copyright file="USCensus.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// Description: POCO Class Mapped With USCensus CSVFile.
    /// </summary>
    public class USCensus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="USCensus"/> class.
        /// </summary>
        public USCensus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="USCensus"/> class.
        /// </summary>
        /// <param name="state">State Name</param>
        /// <param name="stateId">State Id</param>
        /// <param name="population">State Population</param>
        /// <param name="waterArea">State Water Area</param>
        /// <param name="housingUnit">State Housing Unit</param>
        /// <param name="housingDensity">State Housing Density</param>
        /// <param name="landArea">State Land Area</param>
        /// <param name="totalArea">State Total Area</param>
        /// <param name="populationDensity">State Population Density</param>
        public USCensus(string state, string stateId, int population, float waterArea, int housingUnit, float housingDensity, float landArea, float totalArea, float populationDensity)
        {
            this.State = state;
            this.StateId = stateId;
            this.Population = population;
            this.WaterArea = waterArea;
            this.HousingUnits = housingUnit;
            this.HousingDensity = housingDensity;
            this.LandArea = landArea;
            this.HousingDensity = housingDensity;
            this.TotalArea = totalArea;
            this.PopulationDensity = populationDensity;
        }

        [Name("State Id")]
        public string StateId { get; set; }

        [Name("State")]
        public string State { get; set; }

        [Name("Population")]
        public int Population { get; set; }

        [Name("Housing units")]
        public int HousingUnits { get; set; }

        [Name("Total area")]
        public float TotalArea { get; set; }

        [Name("Water area")]
        public float WaterArea { get; set; }

        [Name("Land area")]
        public float LandArea { get; set; }

        [Name("Population Density")]
        public float PopulationDensity { get; set; }

        [Name("Housing Density")]
        public float HousingDensity { get; set; }
    }
}
