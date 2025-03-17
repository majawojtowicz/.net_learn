using NUnit.Framework;

namespace TextAnalyzer.Tests
{
    [TestFixture]
    public class TextAnalyzerTests
    {
        [Test]
        public void Analyze_SimpleText_ShouldCountCharacters()
        {
            var text = "Hello world!";
            var result = TextAnalyzer.Analyze(text);
            Assert.AreEqual(12, result.CharacterCountWithSpaces);
            Assert.AreEqual(11, result.CharacterCountWithoutSpaces);
        }

        [Test]
        public void Analyze_SimpleText_ShouldCountWords()
        {
            var text = "Hello world!";
            var result = TextAnalyzer.Analyze(text);
            Assert.AreEqual(2, result.WordCount);
        }

        [Test]
        public void Analyze_SimpleText_ShouldFindMostCommonWord()
        {
            var text = "Hello world, world short medium lim";
            var result = TextAnalyzer.Analyze(text);
            Assert.AreEqual("world", result.MostCommonWord);
        }

        [Test]
        public void Analyze_EmptyString_ShouldReturnZeros()
        {
            var text = "";
            var result = TextAnalyzer.Analyze(text);
            Assert.AreEqual(0, result.CharacterCountWithSpaces);
            Assert.AreEqual(0, result.WordCount);
            Assert.AreEqual(0, result.SentenceCount);
        }

        [Test]
        public void Analyze_WhitespaceOnly_ShouldReturnZerosButCorrectSpaceCount()
        {
            var text = "      ";
            var result = TextAnalyzer.Analyze(text);
            Assert.AreEqual(6, result.CharacterCountWithSpaces);
            Assert.AreEqual(0, result.CharacterCountWithoutSpaces);
            Assert.AreEqual(0, result.WordCount);
            Assert.AreEqual(0, result.SentenceCount);
        }

        
        [Test]
        public void Analyze_ShouldCorrectlyIdentifyLongestAndShortestWords()
        {
            var text = "Short long medium longest min";
            var result = TextAnalyzer.Analyze(text);
            Assert.AreEqual("longest", result.LongestWord);
            Assert.AreEqual("min", result.ShortestWord);
        }
    }
}