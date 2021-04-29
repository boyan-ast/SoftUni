function solve(input) {
    let hood = new Map();

    let neightborhoods = input.shift().split(', ');

    for (let neightborhood of neightborhoods) {
        hood.set(neightborhood, []);
    }

    for (let person of input) {
        let [neightborhood, name] = person.split(' - ');

        if (hood.has(neightborhood)) {
            let people = hood.get(neightborhood);
            people.push(name);
        }
    }

    let sorted = Array.from(hood.entries());
    
    sorted = sorted.sort(([keyA, inhabitantsA], [keyB, inhabitantsB]) =>
        inhabitantsB.length - inhabitantsA.length);

    for (let kvp of sorted) {
        console.log(`${kvp[0]}: ${kvp[1].length}`);

        for (let inhabitant of kvp[1]) {
            console.log(`--${inhabitant}`);
        }
    }
}

solve(['Abbey Street, Herald Street, Bright Mews',
    'Bright Mews - Garry',
    'Bright Mews - Andrea',
    'Invalid Street - Tommy',
    'Abbey Street - Billy']);