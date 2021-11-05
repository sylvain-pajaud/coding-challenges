using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        var set = new HashSet<int>();
        
        foreach (int nb in A) {
            if (!set.Contains(nb)) {
                set.Add(nb);
            }
        }
        
        return set.Count;
    }
}