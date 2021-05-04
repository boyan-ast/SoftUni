function solve(text, word) {
    let textArray = text.split(' ')
    let count = 0;

    for (let currentWord of textArray) {
        if (currentWord == word) {
            count++;
        }
    }
    console.log(count);
}

solve("This is a word andwordis it also is a sentence", "is");