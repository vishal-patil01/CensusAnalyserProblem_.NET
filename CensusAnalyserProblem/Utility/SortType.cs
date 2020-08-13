using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static CensusAnalyserProblem.CensusEnums;

namespace CensusAnalyserProblem
{
    public class SortType
    {
        public static List<CensusDAO> SortCensusData(List<CensusDAO> list, string sortType, SortOrder sortOrder)
        {
            return sortOrder == SortOrder.ASCENDING ? list.OrderBy(value => value.GetType().GetField(sortType).GetValue(value)).ToList()
                  : list.OrderByDescending(value => value.GetType().GetField(sortType).GetValue(value)).ToList();
        }
    }
}
