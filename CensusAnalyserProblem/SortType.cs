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
            STATE_ASC,STATE_CODE_ASC
        }
        public static List<IndianCensus> SortCensusData(List<IndianCensus> list, SortBy sortType)
        {
            switch (sortType)
            {
                case SortBy.STATE_ASC : return list.OrderBy(c => c.state).ToList();
                default : return list;
            }
        }
        public static List<IndianStateCode> SortStateCodeData(List<IndianStateCode> list, SortBy sortType)
        {
            switch (sortType)
            {
                case SortBy.STATE_CODE_ASC: return list.OrderBy(c => c.stateCode).ToList();
                default: return list;
            }
        }
    }
}
