function sumElements(elements){
    let numbers = elements.map(e => Number(e));
    let sum = numbers[0] + numbers[numbers.length - 1];
    console.log(sum);
}

sumElements(['20', '30', '40']);