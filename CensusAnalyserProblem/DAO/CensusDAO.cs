// <copyright file="CensusDAO.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System;
    using static CensusAnalyserProblem.CensusEnums;

    /// <summary>
    /// Description: CensusDAO For All POCO Class.
    /// </summary>
    public class CensusDAO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        public CensusDAO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="indianCensusCSV">Instance Of IndianCensus POCO</param>
        public CensusDAO(IndianCensus indianCensusCSV)
        {
            this.State = indianCensusCSV.State;
            this.AreaInSqKm = indianCensusCSV.AreaInSqKm;
            this.Population = indianCensusCSV.Population;
            this.PopulationDensity = indianCensusCSV.DensityPerSqKm;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="unitedStatesCensus">Instance Of USCensus POCO</param>
        public CensusDAO(USCensus unitedStatesCensus)
        {
            this.StateCode = unitedStatesCensus.StateId;
            this.State = unitedStatesCensus.State;
            this.Population = unitedStatesCensus.Population;
            this.AreaInSqKm = unitedStatesCensus.TotalArea;
            this.PopulationDensity = unitedStatesCensus.PopulationDensity;
            this.HousingDensity = unitedStatesCensus.HousingDensity;
            this.LandArea = unitedStatesCensus.LandArea;
            this.WaterArea = unitedStatesCensus.WaterArea;
            this.HousingUnits = unitedStatesCensus.HousingUnits;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDAO"/> class.
        /// </summary>
        /// <param name="indianStateCode">Instance Of IndianStateCode POCO</param>
        public CensusDAO(IndianStateCode indianStateCode)
        {
            this.SrNo = indianStateCode.SrNo;
            this.State = indianStateCode.State;
            this.TIN = indianStateCode.TIN;
            this.StateCode = indianStateCode.StateCode;
        }

        public float AreaInSqKm { get; set; }

        public string State { get; set; }

        public int Population { get; set; }

        public float PopulationDensity { get; set; }

        public int SrNo { get; set; }

        public int TIN { get; set; }

        public string StateCode { get; set; }

        public float HousingDensity { get; set; }

        public float LandArea { get; set; }

        public float WaterArea { get; set; }

        public int HousingUnits { get; set; }

        /// <summary>
        /// Description: Return DAO Object Based On dynamic Object Type
        /// </summary>
        /// <param name="objType">dynamic object</param>
        /// <returns>Instance Of CensusDAO</returns>
        public static CensusDAO GetDAO(dynamic objType)
        {
            Type type = objType.GetType();
            if (type == new IndianCensus().GetType())
            {
                return new CensusDAO((IndianCensus)objType);
            }

            if (type == new USCensus().GetType())
            {
                return new CensusDAO((USCensus)objType);
            }

            return new CensusDAO((IndianStateCode)objType);
        }

        /// <summary>
        /// Description: Return Instance Of POCO Classes Based On DTO Format
        /// </summary>
        /// <param name="dtoFormat">Enum For DTO Format</param>
        /// <param name="censusDAO">Instance Of CensusDAO</param>
        /// <returns>Returns Object Based On DTOFormat</returns>
        public object GetDTO(DTO dtoFormat, CensusDAO censusDAO)
        {
            if (dtoFormat.Equals(DTO.INDIA_CENSUS))
            {
                return new IndianCensus(censusDAO.State, censusDAO.Population, censusDAO.AreaInSqKm, censusDAO.PopulationDensity);
            }

            if (dtoFormat.Equals(DTO.INDIA_STATE_CODE))
            {
                return new IndianStateCode(censusDAO.State, censusDAO.SrNo, censusDAO.TIN, censusDAO.StateCode);
            }

            return new USCensus(censusDAO.State, censusDAO.StateCode, censusDAO.Population, censusDAO.WaterArea, censusDAO.HousingUnits, censusDAO.HousingDensity, censusDAO.LandArea, censusDAO.AreaInSqKm, censusDAO.PopulationDensity);
        }
    }
}
