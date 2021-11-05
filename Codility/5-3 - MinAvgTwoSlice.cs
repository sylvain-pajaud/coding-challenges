using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

// NE MARCHE PAS

class Solution {
    public int solution(int[] A) {
        if (A.Length < 2) {
            throw new Exception("A must contain at least 2 elements");
        }
        
        int res = 0;
        int sliceStart = 0;
        int sliceLen = 2;
        float sliceSum = A[0] + A[1];
        float lowestAvg = sliceSum / sliceLen;
        float oldAvg = sliceSum / sliceLen;
        
        for (int i = 1; i < A.Length - 1; i++) {
            float newAvg = (sliceSum + A[i + 1]) / (sliceLen + 1);
            
            Console.WriteLine($"sliceSum: {sliceSum}; sliceSum + A[i + 1]: {sliceSum + A[i + 1]}; oldAvg: {oldAvg}; newAvg: {newAvg}; sliceLen: {sliceLen}");
            
            if (newAvg < oldAvg) {
                sliceLen++;
                oldAvg = newAvg;
            } else {
                sliceLen = 2;
                sliceSum = A[i] + A[i + 1];
                Console.WriteLine($"oldAvg: {oldAvg}; lowestAvg: {lowestAvg}; sliceStart: {sliceStart}");
                if (oldAvg < lowestAvg) {
                    lowestAvg = oldAvg;
                    res = sliceStart;
                }
                oldAvg = sliceSum / sliceLen;
                sliceStart = i;
                Console.WriteLine($"sliceStart: {sliceStart}");
            }
            
            if (oldAvg < lowestAvg) {
                res = sliceStart;
            }
            
        }
        
        return res;
    }
}