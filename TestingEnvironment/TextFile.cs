using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEnvironment
{
    public class TextFile
    {
        private Dictionary<string, int> words = new Dictionary<string, int>();
        public TextFile()
        {
            words = new Dictionary<string, int>();
        }
        /// <summary>
        /// Add a word (key) to the dictionary, if it already exists, add to the value
        /// </summary>
        /// <param name="word"></param>
        public void PopulateWords(string word)
        {
            if (words.ContainsKey(word))
            {
                words[word]++;
            }
            else
            {
                words.Add(word, 1);
            }
        }
        /// <summary>
        /// Divide a likely large dictionary into two smaller dictionaries
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int>[] DivideDict()
        {
            Dictionary<string, int>[] dictionaries = new Dictionary<string, int>[2];

            var half = words.Count / 2;
            var firstDict = words.Take(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            var secondDict = words.Skip(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            dictionaries[0] = firstDict;
            dictionaries[1] = secondDict;
            return dictionaries;
        }
        /// <summary>
        /// Return the most occurring word within that dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public KeyValuePair<string, int> GetMostOccurringWordInDict(Dictionary<string, int> dictionary)
        {
            KeyValuePair<string, int> mostOccurring = dictionary.First();
            foreach (KeyValuePair<string, int> word in dictionary)
            {
                if (mostOccurring.Value < word.Value)
                {
                    mostOccurring = word;
                }
            }
            return mostOccurring;
        }

        /// <summary>
        /// Return the most occurring word out of all dictionaries and how many occurences it has
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<string, int> GetResult()
        {
            Dictionary<string, int>[] dict = DivideDict();
            KeyValuePair<string, int> mostOccurringFirst = GetMostOccurringWordInDict(dict[0]);
            KeyValuePair<string, int> mostOccurringSecond = GetMostOccurringWordInDict(dict[1]);

            if (mostOccurringFirst.Value < mostOccurringSecond.Value)
            {
                return mostOccurringSecond;
            }
            else
            {
                return mostOccurringFirst;
            }
        }
    }
}
