function solve (numbers, order) {
    let sorter = {
        asc: function (elements) {
            return elements.sort((a, b) => a - b);
        },
        desc: function (elements) {
            return elements.sort((a, b) => b - a);
        }
    };

    return sorter[order](numbers);
}


console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));