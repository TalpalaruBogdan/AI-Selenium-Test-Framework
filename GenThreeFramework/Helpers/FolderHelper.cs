using GenThreeFramework.Config;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;

namespace GenThreeFramework.Helpers
{
    public class FolderHelper
    {
        public static void RegisterDOMSnapshot(List<string> snapshot, string testCase)
        {
            if (!File.Exists(Configuration.BaseSnapshotsFolder + testCase + ".txt"))
            {
                //File.Create(Configuration.BaseSnapshotsFolder + testCase + ".txt");
                File.WriteAllLines(Configuration.BaseSnapshotsFolder + testCase + ".txt", snapshot);
            }
            else
            {
                //File.Create(Configuration.ComparisonSnapshotsFolder + testCase + ".txt");
                File.WriteAllLines(Configuration.ComparisonSnapshotsFolder + testCase + ".txt", snapshot);
            }
        }

        public static void SavePictures(Screenshot snapshot, string testCase)
        {
            if (!File.Exists(Configuration.BaseSnapshotsFolder + testCase + ".png"))
            {
                snapshot.SaveAsFile(Configuration.BaseSnapshotsFolder + testCase + ".png");
            }
            else
            {
                snapshot.SaveAsFile(Configuration.ComparisonSnapshotsFolder + testCase + ".png");
            }
        }
    }
}
