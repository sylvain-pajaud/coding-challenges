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
        
        int len = B - A + 1;
        
        if (K == 1) {
            return len;
        } else if (K == 2) {
            if (len % 2 == 1 && B % 2 == 0) {
                return (len / 2) + 1;
            } else {
                return len / 2;
            }
        }
        
        int res = 0;
        int min = A;
        if (min % K != 0) {
            min = K * ((A / K) + 1);
        }
        int max = (B / K) * K;
        
        for (int i = min; i <= max; i += K) {
            if (i % K == 0) {
                res++;
            }
        }
        
        return res;
    }
}