using System.Collections.Generic;
using System.Linq;

namespace EnglishDictionary.Domain
{
	public interface IWordsDB
	{
		IEnumerable<string> Get(string from = null, string to = null);
		string Get(int index);
		void Add(string word);
		void Update(int index, string word);
		void Delete(int index);
		void Delete(string word);
	}

	public class WordsDB : IWordsDB
	{
		List<string> Words { get; set; }

		public WordsDB(IEnumerable<string> words)
		{
			Words = words.ToList();
		}

		public IEnumerable<string> Get(string from, string to)
		{
			return Words.Where(x => (from == null || string.Compare(x, from, true) >= 0) && (to == null || string.Compare(x, to, true) <= 0));
		}

		public string Get(int index)
		{
			return Words[index];
		}

		public void Add(string word)
		{
			Words.Add(word);
		}

		public void Update(int index, string word)
		{
			Words[index] = word;
		}

		public void Delete(int index)
		{
			Words.RemoveAt(index);
		}

		public void Delete(string word)
		{
			Words.Remove(word);
		}
	}
}
