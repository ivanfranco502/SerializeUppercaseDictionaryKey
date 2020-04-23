using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SerializeUppercaseDictionaryKey
{
	class Program
	{
		static void Main(string[] args)
		{
			DailyHighScores dailyHighScores = new DailyHighScores
			{
				Date = new DateTime(2016, 6, 27, 0, 0, 0, DateTimeKind.Utc),
				Game = "Donkey Kong",
				UserPoints = new Dictionary<string, int>
				{
					{"JamesNK", 9001 },
					{"JoC", 1337 },
					{"JessicaN", 1000 }
				}
			};

			DefaultContractResolver contractResolver = new DefaultContractResolver
			{
				NamingStrategy = new CamelCaseNamingStrategy
				{
					ProcessDictionaryKeys = false
				}
			};

			string json = JsonConvert.SerializeObject(dailyHighScores, new JsonSerializerSettings
			{
				ContractResolver = contractResolver,
				Formatting = Formatting.Indented
			});

			Console.WriteLine(json);
			Console.Read();
		}

		public class DailyHighScores
		{
			public DateTime Date { get; set; }
			public string Game { get; set; }
			public Dictionary<string, int> UserPoints { get; set; }
		}
	}
}
