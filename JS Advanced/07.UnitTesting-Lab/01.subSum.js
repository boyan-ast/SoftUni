function subSum(array, startIndex, endIndex) {
    if(!Array.isArray(array)) {
        return NaN;
    }

    if (array.some(el => isNaN(el))) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex > array.length - 1) {
        endIndex = array.length - 1;
    }

    let result = array
        .slice(startIndex, endIndex + 1)
        .reduce((a, x) => a + x, 0);

        return result;

}

// console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300));
// console.log(subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
// console.log(subSum([10, 'twenty', 30, 40], 0, 2));
// console.log(subSum([], 1, 2));
console.log(subSum('text', 0, 2));