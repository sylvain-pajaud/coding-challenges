using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        var set = new HashSet<int>();
        
        if (A.Length == 0) {
            return 0;
        }
        
        foreach (int nb in A) {
            if (nb < 1 || nb > A.Length || set.Contains(nb)) {
                return 0;
            }
            set.Add(nb);
        }
        
        return 1;
    }
}