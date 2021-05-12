function solve(steps, footprint, speedKmH) {
    let distance = steps * footprint;
    let restTimeMin = Math.floor(distance / 500);

    let speed = speedKmH * (1000/3600);
    let totalTimeInSeconds = distance / speed + restTimeMin * 60;

    let hours = Math.floor(totalTimeInSeconds / 3600);
    let minutes = Math.floor((totalTimeInSeconds - (hours * 3600))/60);
    let seconds = Math.round(totalTimeInSeconds - hours * 3600 - minutes * 60);

    return `${String(hours).padStart(2, '0')}:${String(minutes).padStart(2, '0')}:${String(seconds).padStart(2, '0')}`;
}

console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));