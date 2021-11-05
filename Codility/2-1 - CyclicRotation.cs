using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    private static int GCD(int a, int b)
    {
    	if (a == 0)
    		return b;
    
    	while (b != 0)
    	{
    		if (a > b)
    			a -= b;
    		else
    			b -= a;
    	}
    
    	return a;
    }
    
    private static int LCM(int a, int b)
    {
    	return (a * b) / GCD(a, b);
    }
    
    public int[] solution(int[] A, int K) {
        int arrayLength = A.Length;

        if (arrayLength <= 1) {
            return A;
        }
        
        K = K % arrayLength;

        if (arrayLength == K ||
            K == 0) {
            return A;
        }
        
        // Note: We're on modulo arithmetic
        //
        // We want to do exactly one operation per array item, thus a total of arrayLength operations
        // Each operation will be a "jump" of K length
        //
        // But maybe these jumps will bring us back to the original position before handling all items 
        // (ie: we did less than arrayLength operations)
        // If we do nothing, we can't handle other items, the jumps will always bring us back to already handle items
        //
        // This occurs when the remaining items' positions are not multiples of K
        // Remember, we're on modulo arithmetic, so a item can have all these positions:
        //  item.index + x * arrayLength (For any x)
        //
        // When this occurs, we also need to take care of: "multiples of K + 1", "multiples of K + 2", etc
        // It means, each time we're back to the previous start position we need to start again from a new start position
        // The start positions are always: Old start position + 1
        // 
        // We want to know how many times we need to start from a start position
        //
        // The least common multiple of arrayLength and K indicates the smallest position
        // - That is multiple of K
        // - Go back to original position
        //
        // If we divide this number (LCM(arrayLength, K)) by K we obtain the smallest number of K rotation
        // we can do before we're back to the original position
        //
        // If this number of rotation is arrayLength, only one start is needed
        // Thus, we need to do arrayLength / number of rotation to know how many loops are needed
        int nbLoops = arrayLength / ((LCM(arrayLength, K) / K));
        
        for (int n = 0; n < nbLoops; n++) {
            int i = K + n;
            int l = A[n];
            int l2 = 0;
            
            do {
                l2 = A[i];
                A[i] = l;
                l = l2;
                i = (i + K) % arrayLength;
            }
            while (i != K + n);
        }
        
        return A;
    }
}
