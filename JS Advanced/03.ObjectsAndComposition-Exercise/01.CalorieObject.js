function calorieObject(input) {
    let object = {};

    for (let i = 0; i < input.length - 1; i++) {
        if (i % 2 == 0) {
            object[input[i]] = Number(input[i+1]);
        }
    }

    return object;
}

console.log(calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));