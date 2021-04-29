function phoneBook(input) {
    let phoneBook = {};
    for(let contactInfo of input) {
        let [name, number] = contactInfo.split(' ');
        phoneBook[name] = number;
    }

    for (let contact in phoneBook) {
        console.log(`${contact} -> ${phoneBook[contact]}`);
    }
}

phoneBook(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']);