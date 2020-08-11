using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    public class SortType
    {
        public enum SortBy
        {
            STATE_ASC,STATE_CODE_ASC,POPULATION_DESC
        }
        public static List<IndianCensusDAO> SortIndianCensusData(List<IndianCensusDAO> list, SortBy sortType)
        {
            switch (sortType)
            {
                case SortBy.STATE_ASC : return list.OrderBy(c => c.state).ToList();
                case SortBy.STATE_CODE_ASC: return list.OrderBy(c => c.stateCode).ToList();
                case SortBy.POPULATION_DESC: return list.OrderByDescending(c => c.population).ToList();
                default : return list;
            }
        }
    }
}
