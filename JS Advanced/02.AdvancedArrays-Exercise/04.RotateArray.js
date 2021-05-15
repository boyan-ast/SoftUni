function rotateArray(elements, rotations) {
    if (rotations >= elements.length) {
        rotations %= elements.length;
    }

    for (let i = 0; i < rotations; i++) {
        let lastElement = elements.pop();
        elements.unshift(lastElement);
    }

    return elements.join(' ');
}

console.log(rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 15));