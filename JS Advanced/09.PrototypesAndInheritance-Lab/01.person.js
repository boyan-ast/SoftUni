function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
    Object.defineProperty(this, 'fullName', {
        get: function () {
            return `${this.firstName} ${this.lastName}`;
        },
        set: function (value) {
            let validInputRegex = /^(?<firstName>\w+) (?<lastName>\w+)$/;
            let matchedName = value.match(validInputRegex);
            if (matchedName) {
                this.firstName = matchedName.groups.firstName;
                this.lastName = matchedName.groups.lastName;
            }
        }
    })
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla
