'use strict';

// See challenge description here: https://www.hackerrank.com/challenges/crush/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', function(inputStdin) {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.split('\n');

    main();
});

function readLine() {
    return inputString[currentLine++];
}

/*
 * Complete the 'arrayManipulation' function below.
 *
 * The function is expected to return a LONG_INTEGER.
 * The function accepts following parameters:
 *  1. INTEGER n
 *  2. 2D_INTEGER_ARRAY queries
 */

function arrayManipulation(n, queries) {
    let diffs = {};
    let diffIndexes = [];

    // We memorize all interval starts and interval ends
    // At the start of an interval we should increase the count
    // After the end of an interval we should decrease the count
    for (let query of queries) {
        let intervalStart = query[0];
        let intervalEnd = query[1];
        let diff = query[2];
        
        if (diffs[intervalStart] == undefined) {
            diffs[intervalStart] = diff;
            diffIndexes.push(intervalStart);
        } else {
            diffs[intervalStart] += diff;
        }
        
        if (diffs[intervalEnd + 1] == undefined) {
            diffs[intervalEnd + 1] = -diff;
            diffIndexes.push(intervalEnd + 1);
        } else {
            diffs[intervalEnd + 1] -= diff;
        }
    }
    
    let count = 0;
    let maxCount = 0;

    // We play all the count diffs (increases and decreases)
    // and memorize the max count value
    diffIndexes
        .sort((a, b) => a - b)
        .forEach(index => {
            count += diffs[index];
            if (count > maxCount) {
                maxCount = count;
            }
        });
    
    return maxCount;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const firstMultipleInput = readLine().replace(/\s+$/g, '').split(' ');

    const n = parseInt(firstMultipleInput[0], 10);

    const m = parseInt(firstMultipleInput[1], 10);

    let queries = Array(m);

    for (let i = 0; i < m; i++) {
        queries[i] = readLine().replace(/\s+$/g, '').split(' ').map(queriesTemp => parseInt(queriesTemp, 10));
    }

    const result = arrayManipulation(n, queries);

    ws.write(result + '\n');

    ws.end();
}