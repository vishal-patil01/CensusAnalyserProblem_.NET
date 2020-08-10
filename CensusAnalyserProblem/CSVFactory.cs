
namespace CensusAnalyserProblem
{
    class CSVFactory
    {
        public static ICSVDataReader createCSVReader()
        {
            return new CSVDataReader();
        }
    }
}
