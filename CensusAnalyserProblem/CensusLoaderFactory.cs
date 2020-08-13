// <copyright file="CensusLoaderFactory.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using static CensusAnalyserProblem.CensusEnums;
    using static ICSVLoader;

    /// <summary>
    ///  Description: Factory For Loading Census Data Based On Country Type.
    /// </summary>
    public class CensusLoaderFactory 
    {
        /// <summary>
        /// Return a new instance of the <see cref="ICSVLoader"/> class.
        /// </summary>
        /// <param name="country">Enumerator For Specifying Country</param>
        /// <returns>Instance India Or US Loader Based On Condition</returns>
        public static ICSVLoader GetInstance(Country country)
        {
            if (country == Country.INDIA)
            {
                return new IndianCensusLoader();
            }

            return new UsCensusLoader();
        }
    }
}