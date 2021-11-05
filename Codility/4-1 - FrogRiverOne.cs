using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int X, int[] A) {
        bool[] pos = new bool[X];
        int nbLeafs = 0;
        
        for (int i = 0; i < A.Length; i++) {
            int p = A[i];
            
            if (p > X) {
                throw new Exception("Each element of array A must be within the range [1..X].");
            }
            
            if (!pos[p - 1]) {
                if (nbLeafs + 1 == X) {
                    return i;
                }
                
                pos[p - 1] = true;
                nbLeafs++;
            }
        }
        
        return -1;
    }
}
