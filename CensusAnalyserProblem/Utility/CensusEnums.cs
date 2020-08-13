// <copyright file="CensusEnums.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    /// <summary>
    /// Description:Contains All Enumerator Required For Project.
    /// </summary>
    public class CensusEnums
    {
        /// <summary>
        /// Description: Enumerator For Various Sorting Fields
        /// </summary>
        public enum SortBy
        {
            STATE, STATE_CODE, POPULATION, POPULATION_DENSITY, AREA_IN_SQ_KM, DENSITY_PER_SQ_KM, TOTAL_AREA
        }

        /// <summary>
        /// Description: Enumerator For Various Sort Order.
        /// </summary>
        public enum SortOrder
        {
            ASCENDING, DESCENDING
        }

        /// <summary>
        /// Description: Enumerator For Various Country.
        /// </summary>
        public enum Country
        {
            INDIA, US
        }

        /// <summary>
        /// Description: Enumerator For Various DTO Types.
        /// </summary>
        public enum DTO
        {
            INDIA_CENSUS, INDIA_STATE_CODE, US
        }
    }
}
