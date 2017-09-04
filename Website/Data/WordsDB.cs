using System.Collections.Generic;
using System.Linq;

namespace Website.Data
{
	public interface IWordsDB
	{
		IEnumerable<string> GetAll();
		IEnumerable<string> Get(string from, string to);
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

		public IEnumerable<string> GetAll()
		{
			return Words;
		}

		public IEnumerable<string> Get(string from, string to)
		{
			return Words.Where(x => string.Compare(from, x) < 0 && string.Compare(to, x) > 0);
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
