function solve (...args) {
    let types = {};

    for (let arg of args) {
        let type = typeof arg;
        console.log(`${type}: ${arg}`);

        if (types[type] == undefined) {
            types[type] = 0;
        }

        types[type]++;
    }

    let sorted = Object.entries(types).sort((a, b) => b[1] - a[1]);
    
    for (let pair of sorted) {
        console.log(`${pair[0]} = ${pair[1]}`);
    }
}

solve('cat', 42, function () { console.log('Hello world!'); }, 'asdasd', 10, 20);