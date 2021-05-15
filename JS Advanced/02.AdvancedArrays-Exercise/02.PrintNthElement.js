function solve(array, step) {
    const result = array.filter((e, i) => i % step == 0);
    return result;
}

console.log(solve(['dsa',
'asd', 
'test', 
'tset'], 
2
));