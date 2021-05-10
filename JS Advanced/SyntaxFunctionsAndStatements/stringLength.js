function stringLength(...params) {
    let sum = params.reduce((a, b) => a + b.length, 0);
    let average = sum / params.length;
    average = Math.floor(average);
    console.log(sum);
    console.log(average);
}

stringLength('chocolate', 'ice cream', 'cake');