// <copyright file="IndianStateCode.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// Description: POCO Class Mapped With Indian State Code CSVFile .
    /// </summary>
    public class IndianStateCode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndianStateCode"/> class.
        /// </summary>
        public IndianStateCode() 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianStateCode"/> class.
        /// </summary>
        /// <param name="state">State Name</param>
        /// <param name="serialNo">State Serial Number</param>
        /// <param name="tin">State TIN</param>
        /// <param name="stateCode">State Code</param>
        public IndianStateCode(string state, int serialNo, int tin, string stateCode)
        {
            this.State = state;
            this.SrNo = serialNo;
            this.TIN = tin;
            this.StateCode = stateCode;
        }

        [Name("SrNo")]
        public int SrNo { get; set; }

        [Name("State Name")]
        public string State { get; set; }

        [Name("TIN")]
        public int TIN { get; set; }

        [Name("StateCode")]
        public string StateCode { get; set; }
    }
}
