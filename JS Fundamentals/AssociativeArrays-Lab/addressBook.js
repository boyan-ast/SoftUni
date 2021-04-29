function addressBook (input) {
    let addressBook = {};

    for (let person of input) {
        let [name, address] = person.split(':');
        addressBook[name] = address;
    }

    let sorted = Object.entries(addressBook);

    sorted = sorted.sort(([keyA, valueA], [keyB, valueB]) => keyA.localeCompare(keyB));

    for (let person of sorted) {
        console.log(`${person[0]} -> ${person[1]}`);
    }
}

addressBook(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']);