
namespace CensusAnalyserProblem
{
    class CSVFactory
    {
        public static ICSVDataReader CreateCSVReader()
        {
            return new CSVDataReader();
        }
    }
}
