class Bank {
    constructor(name) {
        this._bankName = name;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let customerIndex = this.allCustomers
            .findIndex(c => c.firstName == customer.firstName && c.lastName == customer.lastName && c.personalId == customer.personalId);

        if (customerIndex !== -1) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        let customerIndex = this.allCustomers.findIndex(c => c.personalId == personalId);

        if (customerIndex === -1) {
            throw new Error('We have no customer with this ID!');
        }

        let customer = this.allCustomers[customerIndex];

        if (!customer.hasOwnProperty('totalMoney')) {
            customer.totalMoney = 0;
        }

        customer.totalMoney += amount;
        if (!customer.hasOwnProperty('transactions')) {
            customer.transactions = [];
        }
        customer.transactions.push({ 'made deposit of': amount });

        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customerIndex = this.allCustomers.findIndex(c => c.personalId == personalId);

        if (customerIndex === -1) {
            throw new Error('We have no customer with this ID!');
        }

        let customer = this.allCustomers[customerIndex];

        if (customer.totalMoney == undefined || (customer.totalMoney < amount)) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;

        if (!customer.hasOwnProperty('transactions')) {
            customer.transactions = [];
        }
        customer.transactions.push({ 'withdrew': amount });

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customerIndex = this.allCustomers.findIndex(c => c.personalId == personalId);

        if (customerIndex === -1) {
            throw new Error('We have no customer with this ID!');
        }

        let customer = this.allCustomers[customerIndex];
        let result = [];

        if (!customer.hasOwnProperty('totalMoney')) {
            customer.totalMoney = 0;
        }

        if (!customer.hasOwnProperty('transactions')) {
            customer.transactions = [];
        }

        result.push(`Bank name: ${this._bankName}`);
        result.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        result.push(`Customer ID: ${customer.personalId}`);
        result.push(`Total Money: ${customer.totalMoney}$`);
        result.push(`Transactions:`);

        for (let index = customer.transactions.length - 1; index >= 0; index--) {
            result.push(`${index+1}. ${customer.firstName} ${customer.lastName} ${Object.keys(customer.transactions[index])[0]} ${Object.values(customer.transactions[index])[0]}$!`);
        }

        return result.join('\n');
    }
}


let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
