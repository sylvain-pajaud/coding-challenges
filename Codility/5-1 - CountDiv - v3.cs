using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

// Using Prefix Sums

class Solution {
    public int solution(int A, int B, int K) {
        if (A % K == 0) {
            return (B / K) - (A / K) + 1;
        } else {
            return (B / K) - (A / K);
        }
    }
}
