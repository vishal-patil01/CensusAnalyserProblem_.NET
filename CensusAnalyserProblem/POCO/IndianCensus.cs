using CsvHelper.Configuration.Attributes;
using System;
using System.Dynamic;

namespace CensusAnalyserProblem
{
    public class IndianCensus
    {
        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public int population { get; set; }

        [Name("AreaInSqKm")]
        public int totalArea { get; set; }

        [Name("DensityPerSqKm")]
        public int populationDensity { get; set; }

        public IndianCensus() { }
        public IndianCensus(string state, int population, float totalArea, float populationDensity)
        {
            this.state = state;
            this.population = population;
            this.totalArea = Convert.ToInt32(totalArea);
            this.populationDensity = Convert.ToInt32(populationDensity);
        }
    }
}
