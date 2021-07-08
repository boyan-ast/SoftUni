let ulPhonebookElement = document.getElementById('phonebook');
let loadButton = document.getElementById('btnLoad');
let createButton = document.getElementById('btnCreate');
let personInputElement = document.getElementById('person');
let phoneInputElement = document.getElementById('phone');

let baseUrl = 'http://localhost:3030/jsonstore/phonebook';

function attachEvents() {
    loadButton.addEventListener('click', loadEntries);
    createButton.addEventListener('click', createEntry);
}

function loadEntries(e) {
    fetch(baseUrl)
        .then(response => response.json())
        .then(entries => {
            Array.from(ulPhonebookElement.children).forEach(el => el.remove());

            Object.values(entries).forEach(x => {
                let person = x.person;
                let phone = x.phone;
                let key = x._id;

                let liElement = document.createElement('li');
                liElement.textContent = `${person}: ${phone}`;

                let deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';

                deleteButton.addEventListener('click', function () {
                    deleteEntry(key);
                });

                liElement.appendChild(deleteButton);

                ulPhonebookElement.appendChild(liElement);
            });
        })
        .catch(error => catchError(error));
}

function deleteEntry(id) {
    fetch(`${baseUrl}/${id}`, {
        method: 'DELETE'
    })
        .then(resposne => {
            loadEntries();
        })
        .catch(error => catchError(error));
}

function createEntry(e) {
    if (personInputElement.value.trim() == '' || phoneInputElement.value == '') {
        return;
    }

    let person = personInputElement.value;
    let phone = phoneInputElement.value;

    fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            person,
            phone
        })
    })
        .then(response => {
            loadEntries();
        })
        .catch(error => catchError(error));

    personInputElement.value = '';
    phoneInputElement.value = '';
}

function catchError(error) {
    Array.from(ulPhonebookElement.children).forEach(el => el.remove());
    let h3Element = document.createElement('h3');
    h3Element.textContent = 'Error';
    ulPhonebookElement.appendChild(h3Element);
}

attachEvents();