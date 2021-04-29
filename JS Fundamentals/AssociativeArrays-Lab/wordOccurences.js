function solve(input) {
    let words = new Map();

    for (let word of input) {

        if (!words.has(word)) {
            words.set(word, 0);
        }

        let currentWords = words.get(word);
        currentWords++;

        words.set(word, currentWords);
    }

    let sorted = Array.from(words.entries());
    sorted = sorted.sort(([keyA, valueA], [keyB, valueB]) => valueB - valueA);

    for (let kvp of sorted) {
        console.log(`${kvp[0]} -> ${kvp[1]} times`);
    }
}

solve(["Here", "is", "the", "first", "sentence",
    "Here", "is", "another", "sentence", "And",
    "finally", "the", "third", "sentence"]);