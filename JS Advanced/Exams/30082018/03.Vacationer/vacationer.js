class Vacationer {
    constructor(nameArr, cardArr) {
        this.fullName = nameArr;

        if (cardArr !== undefined) {
            this._validateCard(cardArr[0], undefined, cardArr[2]);
            this.creditCard = {
                cardNumber: cardArr[0],
                expirationDate: cardArr[1],
                securityNumber: cardArr[2]
            }
        } else {
            this.creditCard = {
                cardNumber: 1111,
                expirationDate: '',
                securityNumber: 111
            }
        }

        this.wishList = [];

        this.generateIDNumber();
    }

    set fullName(value) {
        if (value.length !== 3) {
            throw new Error('Name must include first name, middle name and last name');
        }

        let nameRegex = /^(?<firstName>[A-Z][a-z]+) (?<middleName>[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+)$/;

        if (nameRegex.test(value.join(' ')) === false) {
            throw new Error('Invalid full name');
        }

        let matchName = value.join(' ').match(nameRegex);

        this._fullName = {
            firstName: matchName.groups.firstName,
            middleName: matchName.groups.middleName,
            lastName: matchName.groups.lastName
        }
    }

    get fullName() {
        return this._fullName;
    }

    generateIDNumber() {
        let result = 231 * (this._fullName.firstName.charCodeAt(0)) + 139 * this._fullName.middleName.length;
        let lastNameEnding = this._fullName.lastName.charAt(this._fullName.lastName.length - 1);
        if (lastNameEnding == 'a' || lastNameEnding == 'e' || lastNameEnding == 'o' || lastNameEnding == 'i' || lastNameEnding == 'u') {
            result += '8';
        } else {
            result += '7';
        }

        this.idNumber = result;
    }

    addCreditCardInfo(input) {
        if (input.length !== 3) {
            throw new Error('Missing credit card information');
        }

        if (!Number.isInteger(input[0]) || !Number.isInteger(input[2])) {
            throw new Error('Invalid credit card details');
        }

        this.creditCard.cardNumber = input[0];
        this.creditCard.expirationDate = input[1];
        this.creditCard.securityNumber = input[2];
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error('Destination already exists in wishlist');
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {
        let result = [];
        result.push(`Name: ${this._fullName.firstName} ${this._fullName.middleName} ${this._fullName.lastName}`);
        result.push(`ID Number: ${this.idNumber}`);
        result.push('Wishlist:');

        if (this.wishList.length == 0) {
            result.push('empty');
        } else {
            result.push(`${this.wishList.join(', ')}`);
        }

        result.push('Credit Card:');
        result.push(`Card Number: ${this.creditCard.cardNumber}`);
        result.push(`Expiration Date: ${this.creditCard.expirationDate}`);
        result.push(`Security Number: ${this.creditCard.securityNumber}`);

        return result.join('\n');
    }

    _validateCard(cardNumber, expirationDate, securityNumber) {        
        if (!Number.isInteger(cardNumber) || !Number.isInteger(securityNumber)) {
            throw new Error('Invalid credit card details');
        }
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"],
    [123456789, "10/01/2018", 777]);

console.log(vacationer1.fullName);
console.log(vacationer1.idNumber);
console.log(vacationer1.creditCard);
console.log(vacationer2.fullName);
console.log(vacationer2.idNumber);
console.log(vacationer2.creditCard);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
vacationer3.addCreditCardInfo([123456789, "20/10/2018", 100]);

console.log(vacationer3.creditCard);

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

