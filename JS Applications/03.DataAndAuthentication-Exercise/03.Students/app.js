let tableBodyElement = document.querySelector('#results tbody');
let inputForm = document.getElementById('form');

let baseUrl = 'http://localhost:3030/jsonstore/collections/students';

function attachEvents() {
    inputForm.addEventListener('submit', sendData);

    loadEntries();
}

function loadEntries() {
    fetch(baseUrl)
        .then(response => response.json())
        .then(studentsData => {
            Array.from(tableBodyElement.children).forEach(el => el.remove());

            Object.values(studentsData).forEach(s => {
                let trElement = document.createElement('tr');

                let firstNameTdElement = document.createElement('td');
                firstNameTdElement.textContent = s.firstName;

                let lastNameTdElement = document.createElement('td');
                lastNameTdElement.textContent = s.lastName;

                let facultyNumberTdElement = document.createElement('td');
                facultyNumberTdElement.textContent = s.facultyNumber;

                let gradeTdElement = document.createElement('td');
                gradeTdElement.textContent = Number(s.grade).toFixed(2);

                trElement.appendChild(firstNameTdElement);
                trElement.appendChild(lastNameTdElement);
                trElement.appendChild(facultyNumberTdElement);
                trElement.appendChild(gradeTdElement);

                tableBodyElement.appendChild(trElement);
            })
        })
        .catch(error => catchError(error));
}

function sendData(e) {
    e.preventDefault();

    let data = new FormData(e.currentTarget);

    let firstName = data.get('firstName');
    let lastName = data.get('lastName');
    let facultyNumber = data.get('facultyNumber');
    let grade = data.get('grade');

    if (firstName.trim() == ''
        || lastName.trim() == ''
        || isNaN(facultyNumber)
        || isNaN(grade)
        || facultyNumber.trim() == ''
        || grade.trim() == '') {
        return;
    }

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            firstName,
            lastName,
            facultyNumber,
            grade
        })
    })
        .then(response => {
            loadEntries();
        })
        .catch(error => {
            catchError(error);
        });
}

function catchError(error) {
    Array.from(tableBodyElement.children).forEach(el => el.remove());
    let h3Element = document.createElement('h3');
    h3Element.textContent = 'Error';
    tableBodyElement.appendChild(h3Element);
}

attachEvents();