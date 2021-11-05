using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int X, int[] A) {
        var pos = new Dictionary<int, bool>();
        
        for (int i = 0; i < A.Length; i++) {
            int p = A[i];
            
            if (p <= X && !pos.ContainsKey(p)) {
                pos[p] = true;
                
                if (pos.Count == X) {
                    return i;
                }
            }
        }
        
        return -1;
    }
}