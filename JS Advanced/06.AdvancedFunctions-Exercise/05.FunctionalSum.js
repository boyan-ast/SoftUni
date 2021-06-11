function add(num) {
    let sum = num;

    function calculate(secondNum) {
        sum += secondNum;
        return calculate;
    }

    calculate.toString = () => sum;
    return calculate;
}

console.log(add(4)(3).toString());