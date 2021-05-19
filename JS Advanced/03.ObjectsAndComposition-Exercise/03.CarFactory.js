function carFactory(car) {
    const engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ];

    const resultCar = {
        model: car.model,
        engine: {},
        carriage: {},
        wheels: []
    };

    for (let engine of engines) {
        if (car.power <= engine.power) {
            resultCar.engine.power = engine.power;
            resultCar.engine.volume = engine.volume;
            break;
        }
    }

    resultCar.carriage.type = car.carriage;
    resultCar.carriage.color = car.color;

    if (car.wheelsize % 2 == 0) {
        car.wheelsize--;
    }

    for (let i = 0; i < 4; i++) {
        resultCar.wheels.push(car.wheelsize);
    }

    return resultCar;
}

console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));