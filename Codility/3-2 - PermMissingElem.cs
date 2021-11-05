using System;
using System.Linq;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        ISet<int> set = new HashSet<int>();
        for (int i = 1; i < A.Length + 1; i++) {
            set.Add(i);
        }
        
        foreach (int nb in A) {
            set.Remove(nb);
        }
        
        return set.First();
    }
}
