function solve(ticketsInfoArr, sortingCriterion) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (let ticketInfo of ticketsInfoArr) {
        let [destination, price, status] = ticketInfo.split('|');
        price = Number(price);

        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    let sortingBy = {
        destination: (a, b) => { return a.destination.localeCompare(b.destination); },
        price: (a, b) => { return a.price - b.price },
        status: (a, b) => { return a.status.localeCompare(b.status); }
    }

    let sorted = tickets.sort(sortingBy[sortingCriterion]);

    return sorted;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));