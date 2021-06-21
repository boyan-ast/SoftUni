class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw new Error('Not enough parking space.');
        } else {
            let newCar = {
                carModel,
                carNumber,
                payed: false
            };

            this.vehicles.push(newCar);
            return `The ${carModel}, with a registration number ${carNumber}, parked.`;
        }
    }

    removeCar(carNumber) {
        if (this.vehicles.filter(c => c.carNumber == carNumber).length == 0) {
            throw new Error('The car, you\'re looking for, is not found.');
        } else {
            let car = this.vehicles.filter(c => c.carNumber == carNumber)[0];

            if (car.payed == false) {
                throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
            } else {
                this.vehicles = this.vehicles.filter(c => c.carNumber != carNumber);
                return `${carNumber} left the parking lot.`;
            }
        }
    }

    pay(carNumber) {
        if (this.vehicles.filter(c => c.carNumber == carNumber).length == 0) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        } else {
            let car = this.vehicles.filter(c => c.carNumber == carNumber)[0];

            if (car.payed) {
                throw new Error(`${carNumber}\'s driver has already payed his ticket.`);
            } else {
                car.payed = true;
                return `${carNumber}\'s driver successfully payed for his stay.`;
            }
        }
    }

    getStatistics(carNumber) {
        if (carNumber == undefined) {
            let resultArr = [];
            resultArr.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`);
            
            this.vehicles.sort((a,b) => a.carModel.localeCompare(b.carModel));
            
            for (const car of this.vehicles) {
                let payedStr = car.payed ? 'Has payed' : 'Not payed';
                resultArr.push(`${car.carModel} == ${car.carNumber} - ${payedStr}`);
            }

            return resultArr.join('\n');
        } else {
            let car = this.vehicles.filter(c => c.carNumber == carNumber)[0];
            let payedStr = car.payed ? 'Has payed' : 'Not payed';
            return `${car.carModel} == ${car.carNumber} - ${payedStr}`
        }
    }
}


const parking = new Parking(3);

console.log(parking.addCar("Zolvo t600", "EB3691CA"));
console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());


console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));

console.log(parking.removeCar("TX3691CA"));
console.log(parking.getStatistics('EB3691CA'));





