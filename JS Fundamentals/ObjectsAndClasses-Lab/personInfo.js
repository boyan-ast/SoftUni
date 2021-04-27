function personInfo(firstName, lastName, age) {
    let person = {
        firstName: firstName,
        lastName: lastName,
        age: Number(age)
    };

    return person;
}

console.log(personInfo('Bobby', 'Silva', '22'));