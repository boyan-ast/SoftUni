let loadBooksButton = document.getElementById('loadBooks');
let tBodyElement = document.querySelector('table tbody');
let formElement = document.getElementsByTagName('form')[0];

let baseUrl = 'http://localhost:3030/jsonstore/collections/books';

function sovle() {
    loadBooksButton.addEventListener('click', loadBooks);
    formElement.addEventListener('submit', addBook);
}

function addBook(e) {
    e.preventDefault();

    let data = new FormData(e.currentTarget);
    let title = data.get('title');
    let author = data.get('author');

    if (title.trim() == '' || author.trim() == '') {
        return;
    }

    let bookObj = {
        author,
        title
    }

    fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(bookObj)
    })
        .then(response => {
            if (response.ok) {
                loadBooks();
            } else {
                throw new Error();
            }
        })
        .catch(error => { tBodyElement.textContent = 'Error'; });

    formElement.reset();
}

function loadBooks() {
    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            Array.from(tBodyElement.children).forEach(el => el.remove());

            Object.keys(data).forEach(key => {
                let trElement = document.createElement('tr');
                let titleTdElement = document.createElement('td');
                titleTdElement.textContent = data[key].title;
                let authorTdElement = document.createElement('td');
                authorTdElement.textContent = data[key].author;
                let buttonsTdElement = document.createElement('td');

                let editButton = document.createElement('button');
                editButton.textContent = 'Edit';

                editButton.addEventListener('click', function (e) {
                    editBook(e, key);
                });

                let deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';

                deleteButton.addEventListener('click', function (e) {
                    deleteBook(e, key);
                });

                buttonsTdElement.appendChild(editButton);
                buttonsTdElement.appendChild(deleteButton);

                trElement.appendChild(titleTdElement);
                trElement.appendChild(authorTdElement);
                trElement.appendChild(buttonsTdElement);

                tBodyElement.appendChild(trElement);
            });
        })
        .catch(error => { tBodyElement.textContent = 'Error'; })
}

function editBook(e, key) {
    e.preventDefault();
    let authorTdElement = e.currentTarget.parentElement.previousElementSibling;
    let titleTdElement = authorTdElement.previousElementSibling;

    let author = authorTdElement.textContent;
    let title = titleTdElement.textContent;

    let titleInputElement = formElement.querySelector('input[name="title"]');
    let authorInputElement = formElement.querySelector('input[name="author"]');

    titleInputElement.value = title;
    authorInputElement.value = author;

    let h3FormElement = formElement.querySelector('h3');
    let formButton = formElement.querySelector('button');

    h3FormElement.textContent = 'Edit FORM';
    formButton.textContent = 'Save';

    formElement.removeEventListener('submit', addBook);
    formElement.addEventListener('submit', changeBook);

    function changeBook(e) {
        e.preventDefault();
        let newAuthor = authorInputElement.value;
        let newTitle = titleInputElement.value;

        if (newTitle.trim() == '' || newAuthor.trim() == '') {
            return;
        }

        fetch(`${baseUrl}/${key}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                author: newAuthor,
                title: newTitle
            })
        })
            .then(response => {
                if (response.ok) {
                    h3FormElement.textContent = 'FORM';
                    formButton.textContent = 'Submit';

                    titleInputElement.value = '';
                    authorInputElement.value = '';

                    formElement.addEventListener('submit', addBook);
                    formElement.removeEventListener('submit', changeBook);
                    loadBooks();
                } else {
                    throw new Error();
                }
            })
            .catch(error => { tBodyElement.textContent = 'Error'; });
    }
}

function deleteBook(e, key) {
    e.preventDefault();

    fetch(`${baseUrl}/${key}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                loadBooks();
            }
        })
}

sovle();