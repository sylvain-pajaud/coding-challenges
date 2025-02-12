// See challenge description here: https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int Count(string l, string r)
    {
        int count = 0;
        
        var lDict = l.ToCharArray().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        
        int len = l.Length;
        for (int i = 0; i + len < r.Length + 1; i++)
        {
            //var rDict = r.Substring(i, len).ToCharArray().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            
            var rDict = new Dictionary<char, int>();
            for (int j = 0; j < len; j++) {
                if (!rDict.ContainsKey(r[i + j])) {
                    rDict.Add(r[i + j], 1);
                } else {
                    rDict[r[i + j]]++;
                }
            }
            
            //Console.WriteLine($">{l} {r.Substring(i, len)}");
            
            bool found = true;
            
            foreach (var kvp in rDict) {
                if (!lDict.ContainsKey(kvp.Key) || lDict[kvp.Key] != kvp.Value)
                {
                   found = false;
                   break;
                }
            }
            
            if (found) {
                count++;
            }
        }
        
        return count;
    }

    public static int sherlockAndAnagrams(string s)
    {
        int count = 0;
        
        for (int j = 0; j < s.Length; j++) {
            var r = s.Substring(j + 1);
            for (int i = j; i + 1 < s.Length; i++) {
                var l = s.Substring(j, (i - j) + 1);
                
                count += Count(l, r);
                //Console.WriteLine($"{l} {r}");
            }
        }
        
        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
