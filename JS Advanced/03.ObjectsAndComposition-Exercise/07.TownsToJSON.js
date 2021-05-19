function townsToJSON(input) {
    let headingsLine = input.shift();
    
    let towns = [];

    for (let line of input) {
        let tokens = line.slice(2, line.length - 2).split(' | ');
        let town = tokens[0];
        let lat = Number(tokens[1]).toFixed(2);
        let lon = Number(tokens[2]).toFixed(2);

        towns.push({Town: town, Latitude: Number(lat), Longitude: Number(lon)});
    }

    return JSON.stringify(towns);
}

console.log(townsToJSON([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));