using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DocumentDistance
{
    class DocDistance
    {
        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();


            string doc1 = File.ReadAllText(doc1FilePath).ToLower();
            string[] words1 = null;
            Regex regex = new Regex("[^a-zA-Z0-9]", RegexOptions.Compiled);
            string text1 = regex.Replace(doc1, " ");

            string doc2 = File.ReadAllText(doc2FilePath).ToLower();
            string[] words2 = null;
            string text2 = regex.Replace(doc2, " ");

            Dictionary<string, long> dict1 = new Dictionary<string, long>();
            Dictionary<string, long> dict2 = new Dictionary<string, long>();
            Dictionary<string, long> dict3 = new Dictionary<string, long>();
            double d1d2 = 0;
            double d1 = 0;
            double d2 = 0;
            double D1D2 = 0;





            words1 = text1.Split(' ');
            words2 = text2.Split(' ');




            /*foreach (var word in words1)
                System.Console.WriteLine($"{word}" + " wow1");
            foreach (var word in words2)
                System.Console.WriteLine($"{word}" + " wow2");*/

            foreach (var word in words1)
            {
                if (!dict1.ContainsKey(word) && !word.Equals(""))
                {
                    dict1.Add($"{word}", 1);
                }
                else if (!word.Equals(""))
                    dict1[word] += 1;

                if (!dict3.ContainsKey(word) && !word.Equals(""))
                {
                    dict3.Add($"{word}", 1);
                }
                else if (!word.Equals(""))
                    dict3[word] += 1;
                //System.Console.WriteLine($"{word}");
            }

            foreach (var word in words2)
            {

                if (!dict2.ContainsKey(word) && !word.Equals(""))
                {
                    dict2.Add($"{word}", 1);
                }
                else if (!word.Equals(""))
                    dict2[word] += 1;

                if (!dict3.ContainsKey(word) && !word.Equals(""))
                {
                    dict3.Add($"{word}", 1);
                }
                else if (!word.Equals(""))
                    dict3[word] += 1;
                //System.Console.WriteLine($"{word}");
            }


            foreach (var key in dict3.Keys)
            {
                if (dict1.ContainsKey(key) && dict2.ContainsKey(key))
                {
                    d1d2 += (dict1[key] * dict2[key]);
                    d1 += (Math.Pow(dict1[key], 2));
                    d2 += (Math.Pow(dict2[key], 2));
                }
                else if (dict1.ContainsKey(key) && !dict2.ContainsKey(key))
                {
                    d1 += (Math.Pow(dict1[key], 2));
                }
                else if (!dict1.ContainsKey(key) && dict2.ContainsKey(key))
                {
                    d2 += (Math.Pow(dict2[key], 2));
                }
            }

            D1D2 = d1d2 / (Math.Sqrt(d1 * d2));

            /*foreach (var item in dict3)
            {
                Console.WriteLine("Key " + item.Key + " Value " + item.Value);
            }*/
            double Radians = Math.Acos(D1D2);
            double Degrees = Radians * 180 / Math.PI;
            //Console.WriteLine(" d1 " + d1);
            //Console.WriteLine(" d2 " + d2);
            //Console.WriteLine(" d1d2 " + d1d2);
            // Console.WriteLine(" D1D2 " + D1D2);
            //Console.WriteLine(" Degrees " + Degrees);
            return Degrees;
        }
    }
}