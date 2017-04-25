using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestingEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            string myS = "There once lived a poor tailor, who had a son called Aladdin, a careless, idle boy who would do nothing but play all day long in the streets with little idle boys like himself.  This so grieved the father that he died; yet, in spite of his mother's tears and prayers, Aladdin did not mend his ways.  One day, when he was playing in the streets as usual, a stranger asked him his age, and if he was not the son of Mustapha the tailor.  \"I am, sir,\" replied Aladdin; \"but he died a long while ago.\"  On this the stranger, who was a famous African magician, fell on his neck and kissed him saying: \"I am your uncle, and knew you from your likeness to my brother. Go to your mother and tell her I am coming.\"  Aladdin ran home and told his mother of his newly found uncle.  \"Indeed, child,\" she said, \"your father had a brother, but I always thought he was dead.\" However, she prepared supper, and bade Aladdin seek his uncle, who came laden with wine and fruit.  He fell down and kissed the place where Mustapha used to sit, bidding Aladdin's mother not to be surprised at not having seen him before, as he had been forty years out of the country.  He then turned to Aladdin, and asked him his trade, at which the boy hung his head, while his mother burst into tears.  On learning that Aladdin was idle and would learn no trade, he offered to take a shop for him and stock it with merchandise.  Next day he bought Aladdin a fine suit of clothes and took him all over the city, showing him the sights, and brought him home at nightfall to his mother, who was overjoyed to see her son so fine.";
            string[] brokenDown = myS.Split();
            TextFile txtReader = new TextFile();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            foreach (string line in brokenDown)
            {
                string newString = Regex.Replace(line, "[\",!?. ]", "");
                Console.WriteLine(newString);
                txtReader.PopulateWords(newString.ToLower());
            }
            
            KeyValuePair<string, int> dictionaries = txtReader.GetResult();
            watch.Stop();
            Console.WriteLine(dictionaries.Key + " is the most occuring word with " + dictionaries.Value + " occurrences");
            Console.WriteLine("This function took " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine("\n");

            for (int x = 0; x < brokenDown.Length; x++)
            {
                if(brokenDown[x].ToLower() == dictionaries.Key)
                {
                    brokenDown[x] = "foo" + brokenDown[x] + "bar";
                }
            }
            string newString2 = string.Join(" ", brokenDown);
            Console.WriteLine(newString2);
            Console.WriteLine("\n");
        }
    }
}
