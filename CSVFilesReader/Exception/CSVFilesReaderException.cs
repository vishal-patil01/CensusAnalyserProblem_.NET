using System;

namespace CensusAnalyserProblem
{
    public class CSVFilesReaderException:Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INCORRECT_FILE_FORMAT, INCORRECT_DELIMITER, INCORRECT_HEADER
        }
        public ExceptionType type;

        public CSVFilesReaderException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}
