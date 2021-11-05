using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public static int GetImpactFactor(char nucleotide) {
        switch (nucleotide) {
            case 'A':
                return 1;
            case 'C':
                return 2;
            case 'G':
                return 3;
            case 'T':
                return 4;
            default:
                return 0;
        }
    }
    
    public int[] solution(string S, int[] P, int[] Q) {
        int N = S.Length;
        int M = P.Length < Q.Length ? P.Length : Q.Length;
        
        if (N == 0 || M == 0) {
            return new int[0];
        }
        
        int[] res = new int[M];
        
        var oneDict = new Dictionary<int, int> { [0] = 0 };
        var twoDict = new Dictionary<int, int> { [0] = 0 };
        var threeDict = new Dictionary<int, int> { [0] = 0 };
        
        int oneCount = 0;
        int twoCount = 0;
        int threeCount = 0;
        
        for (int i = 1; i <= S.Length; i++) {
            int impactFactor = GetImpactFactor(S[i - 1]);
            
            if (impactFactor == 1) {
                oneCount++;
            } else if (impactFactor == 2) {
                twoCount++;
            } else if (impactFactor == 3) {
                threeCount++;
            }
            
            oneDict.Add(i, oneCount);
            twoDict.Add(i, twoCount);
            threeDict.Add(i, threeCount);
        }
        
        for (int i = 0; i < M; i++) {
            int p = P[i];
            int q = Q[i];
            
            int rangeOneCount = 0;
            int rangeTwoCount = 0;
            int rangeThreeCount = 0;
            
            if (p < N && q < N) {
                rangeOneCount = oneDict[q + 1] - oneDict[p];
                rangeTwoCount = twoDict[q + 1] - twoDict[p];
                rangeThreeCount = threeDict[q + 1] - threeDict[p];
            }
            
            if (rangeOneCount > 0) {
                res[i] = 1;   
            } else if (rangeTwoCount > 0) {
                res[i] = 2;   
            } else if (rangeThreeCount > 0) {
                res[i] = 3;   
            } else {
                res[i] = 4;
            } 
        }
        
        return res;
    }
}
