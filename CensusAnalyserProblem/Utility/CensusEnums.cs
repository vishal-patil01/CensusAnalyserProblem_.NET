namespace CensusAnalyserProblem
{
    public class CensusEnums
    {
        public enum SortBy
        {
            STATE, STATE_CODE, POPULATION, POPULATION_DENSITY, AREA_IN_SQ_KM
        }
        public enum SortOrder
        {
            ASCENDING, DESCENDING
        }
        public enum Country
        {
            INDIA, US
        }
        public enum DTO
        {
            INDIA_CENSUS, INDIA_STATE_CODE, US
        }
    }
}
