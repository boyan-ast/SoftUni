function solve(input) {
    let words = input.split(/[\W]/);
    words = words.filter(w => w != '').map(w => w.toUpperCase());
    console.log(words.join(', '));
}

solve('Hi, how are you?');