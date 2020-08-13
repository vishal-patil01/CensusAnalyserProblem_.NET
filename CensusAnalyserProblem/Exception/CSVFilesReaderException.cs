// <copyright file="CSVFilesReaderException.cs" company="BridgeLabz">
// Copyright (c) Vishal Rajput. All rights reserved.
// </copyright>
namespace CensusAnalyserProblem
{
    using System;

    /// <summary>
    /// Description: Custom Exception Implementation For CSVFilesReader.
    /// </summary>
    public class CSVFilesReaderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSVFilesReaderException"/> class.
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="type">Exception Type</param>
        public CSVFilesReaderException(string message, CSVReaderExceptionType type) : base(message)
        {
            this.ExceptionType = type;
        }

        /// <summary>
        /// Description: Enum For Define Custom Exception Type For CSVFilesReader.
        /// </summary>
        public enum CSVReaderExceptionType
        {
            FILE_NOT_FOUND, INCORRECT_FILE_FORMAT, INCORRECT_DELIMITER, INCORRECT_HEADER
        }

        public CSVReaderExceptionType ExceptionType { get; set; }
    }
}
