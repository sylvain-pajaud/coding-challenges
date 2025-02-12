# See challenge description here: https://www.hackerrank.com/challenges/balanced-brackets/problem

#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'isBalanced' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING s as parameter.
#

def isBalanced(s):
    stack = []
    
    for char in s:
        if char == '{' or char == '[' or char == '(':
            stack.append(char)
        elif char == '}' or char == ']' or char == ')':
            if len(stack) == 0:
                return 'NO'
            cur = stack.pop()
            
            if (char == '}' and cur != '{') or (char == ']' and cur != '[') or (char == ')' and cur != '('):
                return 'NO'
            
    return 'YES' if len(stack) == 0 else 'NO'

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    t = int(input().strip())

    for t_itr in range(t):
        s = input()

        result = isBalanced(s)

        fptr.write(result + '\n')

    fptr.close()
