using EnglishDictionary.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EnglishDictionary.UnitTests
{
	[TestClass]
	public class WordsDBFixture
	{
		string[] words = new[] { "a", "b", "c", "d" };

		[TestMethod]
		public void Should_return_all_words()
		{
			//Arrange
			IWordsDB sut = new WordsDB(words);

			//Act
			var actual = sut.Get();

			//Assert
			Assert.AreEqual(4, actual.Count());
		}

		[TestMethod]
		public void Should_return_filtered_words()
		{
			//Arrange
			IWordsDB sut = new WordsDB(words);
			const string from = "b", to = "c";
			//Act
			var actual = sut.Get(from, to);

			//Assert
			Assert.AreEqual(2, actual.Count());
		}
	}
}
