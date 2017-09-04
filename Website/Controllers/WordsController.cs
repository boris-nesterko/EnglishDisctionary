using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EnglishDictionary.Domain;

namespace EnglishDictionary.Website.Controllers
{
	[Route("api/words")]
	public class WordsController : Controller
	{
		readonly IWordsDB DB;

		public WordsController(IWordsDB db)
		{
			DB = db;
		}

		//GET api/words
		[HttpGet]
		public IEnumerable<string> Get(string from = null, string to = null)
		{
			return DB.Get(from, to);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return DB.Get(id);
		}

		// POST api/words
		[HttpPost]
		public void Post([FromBody]string word)
		{
			DB.Add(word);
		}

		// PUT api/words/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string word)
		{
			DB.Update(id, word);

		  }

		// DELETE api/words/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			DB.Delete(id);
		}

		// DELETE api/words/5
		[HttpDelete("{word}")]
		public void Delete(string word)
		{
			DB.Delete(word);
		}
	}
}
