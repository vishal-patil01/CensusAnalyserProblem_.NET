namespace CensusAnalyserProblem
{
    class CSVFactory
    {
        public static ICSVReader createCSVReader()
        {
            return new CSVReader();
        }
    }
}
