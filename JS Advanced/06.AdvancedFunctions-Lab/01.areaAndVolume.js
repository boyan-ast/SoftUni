function solve(area, vol, input) {
    let coordinatesArray = JSON.parse(input);

    let coordinatesInNumbers = coordinatesArray.reduce((a, el) => {
        a.push({ x: Number(el.x), y: Number(el.y), z: Number(el.z) });
        return a;
    }, []);

    let output = coordinatesInNumbers.reduce((a, el) => {
        a.push({area: area.call(el), volume: vol.call(el)});
        return a;
    }, []);

    return output;
}

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

console.log(solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]'));