using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class SortType
    {
        public enum SortBy
        {
            STATE,STATE_CODE,POPULATION,POPULATION_DENSITY,AREA_IN_SQ_KM
        }
        public enum SortOrder
        {
            ASCENDING,DESCENDING
        }
        public enum Country
        {
            INDIA, US
        }
        public static List<CensusDAO> SortCensusData(List<CensusDAO> list, string sortType, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.ASCENDING ? list.OrderBy(c => c.GetType().GetField(sortType).GetValue(c)).ToList()
                  : list.OrderByDescending(c => c.GetType().GetField(sortType).GetValue(c)).ToList();
        }
    }
}
