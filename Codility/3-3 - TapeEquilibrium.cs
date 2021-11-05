using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        int total = 0;
        int? res = null;
        
        foreach (int nb in A) {
            total += nb;
        }
        
        for (int i = A.Length - 1; i > 0; i--) {
            total -= A[i] * 2;
            
            if (res == 1) {
                return 1;
            }
            else if (!res.HasValue || Math.Abs(total) < res) {
                res = Math.Abs(total);
            }
        }
        
        return res.Value;
    }
}
