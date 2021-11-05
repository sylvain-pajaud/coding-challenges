using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        int res = 0;
        
        if (A.Length <= 1) {
            return res;
        }
        
        int westCarCount = 0;
        
        for (int i = A.Length - 1; i >= 0; i--) {
            if (A[i] == 1) {
                westCarCount++;
            } else if (A[i] == 0) {
                res += westCarCount;
                
                if (res > 1000000000) {
                    return -1;
                }
            }
        }
        
        return res;
    }
}