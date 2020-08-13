
namespace CensusAnalyserProblem
{
   public class CSVFactory
    {
        public static ICSVDataReader CreateCSVReader()
        {
            return new CSVDataReader();
        }
    }
}
