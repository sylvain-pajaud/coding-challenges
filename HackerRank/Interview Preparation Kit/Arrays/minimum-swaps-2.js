'use strict';

// See challenge description here: https://www.hackerrank.com/challenges/minimum-swaps-2

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', inputStdin => {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.replace(/\s*$/, '')
        .split('\n')
        .map(str => str.replace(/\s*$/, ''));

    main();
});

function readLine() {
    return inputString[currentLine++];
}

// Complete the minimumSwaps function below.
function minimumSwaps(arr) {
    let swapCounts = 0;
    let elementPositions = {};
    
    // We create a ditionary to know a position  ased on its element
    for (const [index, element] of arr.entries()) {
        elementPositions[element] = index;
    }
    
    for (const [index, element] of arr.entries()) {
        // The goalis to have elements sorted in ascending order:
        // Ex: arr[0] = 1, arr[1] = 2, arr[2] =2 etc
        // If the current element is not at the correct position
        // we swap it with the correct element
        if ((index + 1) != element) {
            // We find the correct element using elementPositions dictionary
            let correctElementPosition = elementPositions[index + 1];

            // We do the swap and update dictipnary accordingly
            
            arr[index] = index + 1;
            elementPositions[index + 1] = index + 1;

            arr[correctElementPosition] = element;
            elementPositions[element] = correctElementPosition;
            
            // We incrememt the swap count
            swapCounts++;
        }
    }
    
    return swapCounts;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const n = parseInt(readLine(), 10);

    const arr = readLine().split(' ').map(arrTemp => parseInt(arrTemp, 10));

    const res = minimumSwaps(arr);

    ws.write(res + '\n');

    ws.end();
}
