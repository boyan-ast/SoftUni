function objectToJson(firstName, lastName, hairColor) {
    let person = {
        name: firstName,
        lastName,
        hairColor
    };

    let personToString = JSON.stringify(person);

    console.log(personToString);
}

objectToJson('George','Jones','Brown');