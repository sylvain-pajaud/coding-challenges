using System;
using System.Linq;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int[] solution(int N, int[] A) {
        int[] counters = new int[N];
        int[] nbMax = new int[N];
        
        int max = 0;
        int totalMax = 0;
        int currentNbMax = 0;
        
        foreach (int instr in A) {
            if (instr >= 1 && instr <= N) {
                if (nbMax[instr - 1] < currentNbMax) {
                    nbMax[instr - 1] = currentNbMax;
                    counters[instr - 1] = 1;
                }
                else {
                    counters[instr - 1]++;
                }
                if (counters[instr - 1] > max) {
                    max = counters[instr - 1];
                }
            } else if (instr == N + 1) {
                totalMax += max;
                max = 0;
                currentNbMax++;
            }
        }
        
        if (totalMax > 0) {
            for (int i = 0; i < N; i++) {
                if (nbMax[i] < currentNbMax) {
                    counters[i] = totalMax;
                } else {
                    counters[i] += totalMax;
                }
            }
        }
        
        return counters;
    }
}
