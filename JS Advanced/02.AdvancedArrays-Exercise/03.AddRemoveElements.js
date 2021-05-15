function solve(elements) {
    const result = [];

    for (let i = 0; i < elements.length; i++) {
        if (elements[i] == 'add') {
            result.push(i + 1);
        } else if (elements[i] == 'remove' && result.length > 0) {
            result.pop();
        }
    }

    return result.length == 0 ? 'Empty' : result.join('\r\n');
}

console.log(solve([['remove', 
'remove', 
'remove']
]));