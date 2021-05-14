function sumFirstLast(elements) {
    if (elements.length == 1) {
        return elements[0] * 2;
    } else {
        return Number(elements.shift()) + Number(elements.pop());
    }
}

console.log(sumFirstLast(['20', '30', '40']));