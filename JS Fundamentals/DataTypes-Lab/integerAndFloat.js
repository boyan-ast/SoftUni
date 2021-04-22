function solve(first, second, third){
    let result = first + second + third;

    result % 1 === 0 ? result += ' - Integer' : result += ' - Float';

    console.log(result);
}

solve(100, 200, 303);