using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LZW;

namespace LZWTests
{
    [TestClass]
    public class LZWFileTests
    {
        [TestMethod]
        public void CompressAndDecompress_VerifyRoundTrip()
        {
            string originalText = "abacabadabacabae";

            string inputFile = Path.GetTempFileName();

            File.WriteAllText(inputFile, originalText);

            LZWAlgorythm.CompressFile(inputFile);

            string zippedFile = inputFile + ".zipped";
            Assert.IsTrue(File.Exists(zippedFile));

            string[] zippedLines = File.ReadAllLines(zippedFile);
            Assert.IsTrue(zippedLines.Length >= 2);

            string compressedData = zippedLines[1];
            Assert.AreEqual("01025039864", compressedData);

            LZWAlgorythm.DecompressFile(zippedFile);

            string unzippedFile = Path.Combine(Path.GetDirectoryName(zippedFile)!, "Unzipped.txt");
            Assert.IsTrue(File.Exists(unzippedFile));

            string decompressedText = File.ReadAllText(unzippedFile);
            Assert.AreEqual(originalText, decompressedText);

            if (File.Exists(inputFile)) File.Delete(inputFile);
            if (File.Exists(inputFile + ".zipped")) File.Delete(inputFile + ".zipped");
            if (File.Exists(unzippedFile)) File.Delete(unzippedFile);
        }
    }
}
