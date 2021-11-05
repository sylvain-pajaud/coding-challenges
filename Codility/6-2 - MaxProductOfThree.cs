using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        if (A.Length < 3) {
            return 0;
        }
        
        int sum1 = 0;
        int sum2 = 0;
        
        var sortedElems = A.OrderByDescending(x => x).ToList();
        
        sum1 = sortedElems[0] * sortedElems[1] * sortedElems[2];
        
        if (sortedElems[A.Length - 1] < 0 && sortedElems[A.Length - 2] < 0) {
            sum2 = sortedElems[0] * sortedElems[A.Length - 1] * sortedElems[A.Length - 2];
        }
        
        return sum1 > sum2 ? sum1 : sum2;
    }
}