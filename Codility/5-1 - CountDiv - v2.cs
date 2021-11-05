using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int A, int B, int K) {
        if (A > B || B < 0 || K < 1) {
            return 0;
        }
        
        if (A < 0) {
            A = 0;
        }
        
        int diff = B - A;
        int res = diff / K;
        
        int innerMod = A % K;
        if (innerMod != 0) {
            innerMod = K - innerMod;
        }
        int outerMod = B % K;
        
        if ((innerMod + outerMod) < K) {
            res++;
        }
        
        return res;
    }
}