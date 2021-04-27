function cityInfo(cityObj) {
    let objKeys = Object.keys(cityObj);

    for (key of objKeys) {
        console.log(`${key} -> ${cityObj[key]}`);
    }
}

cityInfo({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});