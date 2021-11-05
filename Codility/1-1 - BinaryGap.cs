using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int N) {
        int gap = -1;
        int maxGap = 0;
        
        while (N > 0) {
            if (N % 2 == 1) {
                if (gap > maxGap) {
                    maxGap = gap;
                }
                gap = 0;
            } else if (gap >= 0) {
                gap++;
            }
            N = N / 2;
        }
        
        return maxGap;
    }
}
