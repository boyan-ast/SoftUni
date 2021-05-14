function solve(array, start, end) {
    const startIndex = array.indexOf(start);
    const endIndex = array.indexOf(end);

    return array.slice(startIndex, endIndex + 1);
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));