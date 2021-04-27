function stringToObject(objString) {
    let object = JSON.parse(objString);
    let keys = Object.keys(object);

    for (key of keys) {
        console.log(`${key}: ${object[key]}`);
    }
}

stringToObject('{"name": "George", "age": 40, "town": "Sofia"}');