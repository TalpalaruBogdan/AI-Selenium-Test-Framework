using System.IO;

namespace GenThreeFramework.Config
{
    class Configuration
    {
        public static string ChromeDriverPath = Directory.GetCurrentDirectory() + @"\..\..\..\Resources\";
        public static int ImplicitWait = 30;
        public static string BaseSnapshotsFolder = Directory.GetCurrentDirectory() + @"\..\..\..\Snapshots\Base\";
        public static string ComparisonSnapshotsFolder = Directory.GetCurrentDirectory() + @"\..\..\..\Snapshots\Comparison\";
        public static string DifferencesSnapshotsFolder = Directory.GetCurrentDirectory() + @"\..\..\..\Snapshots\Differences\";
        public static decimal ImageTreshold = 0.0025M;
        public static int WaitBeforeSnapshot = 5;
    }
}
