﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TextProcessApp.Models
{
    public class ProcessedText
    {
        public KeyValuePair<string, int> MostOccurringWord { get; set; }
        public string Content { get; set; }
        public Dictionary<string, int> ProcessText { get; set; }

        /// <summary>
        /// Constructor
        /// 
        /// Creating a ProcessedText object will process and find most occurring word on creation
        /// </summary>
        /// <param name="content"></param>
        public ProcessedText(string content)
        {
            ProcessText = new Dictionary<string, int>();
            Content = content;

            string[] contentSplit = content.ToLower().Split();

            for(int i = 0; i < contentSplit.Length; i++)
            {
                contentSplit[i] = Regex.Replace(contentSplit[i], "[\",!?. ]", "");
            }

            PopulateWords(contentSplit);
            SetMostOccurringWord();
        }

        /// <summary>
        /// Add a word (key) to the dictionary, if it already exists, add to the value
        /// </summary>
        /// <param name="word"></param>
        private void PopulateWords(string[] words)
        {
            foreach(string word in words)
            {
                if (ProcessText.ContainsKey(word))
                {
                    ProcessText[word]++;
                }
                else
                {
                    ProcessText.Add(word, 1);
                }
            }
        }

        /// <summary>
        /// Returns an array of two smaller dictionaries
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int>[] DivideDict()
        {
            Dictionary<string, int>[] dictionaries = new Dictionary<string, int>[2];

            var half = ProcessText.Count / 2;
            var firstDict = ProcessText.Take(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            var secondDict = ProcessText.Skip(half).ToDictionary(kv => kv.Key, kv => kv.Value);
            dictionaries[0] = firstDict;
            dictionaries[1] = secondDict;
            return dictionaries;
        }
        /// <summary>
        /// Return the most occurring word within that dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        private KeyValuePair<string, int> GetMostOccurringWordInDict(Dictionary<string, int> dictionary)
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
        private void SetMostOccurringWord()
        {
            Dictionary<string, int>[] dict = DivideDict();
            KeyValuePair<string, int> mostOccurringFirst = GetMostOccurringWordInDict(dict[0]);
            KeyValuePair<string, int> mostOccurringSecond = GetMostOccurringWordInDict(dict[1]);

            if (mostOccurringFirst.Value < mostOccurringSecond.Value)
            {
                MostOccurringWord = mostOccurringSecond;
            }
            else
            {
                MostOccurringWord = mostOccurringFirst;
            }
        }
    }
}