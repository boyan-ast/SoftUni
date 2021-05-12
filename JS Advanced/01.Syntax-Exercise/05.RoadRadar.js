function solve(speed, area) {
    let maxSpeed = 0;

    switch (area) {
        case 'motorway':
            maxSpeed = 130;
            break;
        case 'interstate':
            maxSpeed = 90;
            break;
        case 'city':
            maxSpeed = 50
            break;
        case 'residential':
            maxSpeed = 20;
            break;
        default:
            break;
    }

    if (isInLimits()) {
        return `Driving ${speed} km/h in a ${maxSpeed} zone`;
    } else {
        return `The speed is ${speed - maxSpeed} km/h faster than the allowed speed of ${maxSpeed} - ${findStatus()}`;
    }

    function isInLimits() {
        return speed <= maxSpeed;
    }

    function findStatus() {
        let diff = speed - maxSpeed;

        if (diff <= 20) {
            return 'speeding';
        } else if (diff <= 40) {
            return 'excessive speeding';
        } else {
            return 'reckless driving';
        }
    }
}

console.log(solve(40, 'city'));
console.log(solve(120, 'interstate'));