function sortArray(input) {
    const sorted = input.sort(sortFunc);

    return sorted.join('\r\n');

    function sortFunc(a, b) {
        result = a.length - b.length;

        if (result == 0) {
            result = a.localeCompare(b);
        }

        return result;
    }
}

console.log(sortArray(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));