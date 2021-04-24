function solve(array){
    let lastElementIndex = array.length - 1;
    return array[0] + array[lastElementIndex];
}

console.log(solve([20, 30, 40]));