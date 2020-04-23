using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
				UserPoints = new UserPointsDictionary<string, int>
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
					ProcessDictionaryKeys = true
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
			public UserPointsDictionary<string, int> UserPoints { get; set; }
		}

		[JsonDictionary(NamingStrategyType = typeof(DefaultNamingStrategy))]
		public class UserPointsDictionary<TKey, TValue> : Dictionary<TKey, TValue>
		{
			public UserPointsDictionary()
			{
				
			}
			public UserPointsDictionary(Dictionary<TKey,TValue> dictionary):base(dictionary)
			{
			}
		}
	}
}
