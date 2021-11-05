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
            if (nb > 0) {
                set.Add(nb);
            }
        }
        
        int i = 1;
        while (set.Contains(i)) {
            i++;
        }
        
        return i;
    }
}
