function solution() {
    let value = '';

    return {
        append(input) {
            value += input;
        },
        removeStart(n) {
            value = value.substring(n);
        },
        removeEnd(n) {
            value = value.substring(0, value.length - n);
        },
        print() {
            console.log(value);
        }
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();