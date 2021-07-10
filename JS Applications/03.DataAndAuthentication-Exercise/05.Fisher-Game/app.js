/* Implement logout logic */
let catchesDivElement = document.getElementById('catches');
[...catchesDivElement.children].forEach(el => el.remove());

let loginElement = document.querySelector('#guest a');

if (localStorage.getItem('token')) {
    loginElement.textContent = 'Logout';
}

loginElement.addEventListener('click', logout);

async function logout(e) {
    if (localStorage.getItem('token')) {
        loginElement.textContent = 'Login';
        localStorage.clear();
    }
}

/* Implement page logic */
let baseUrl = 'http://localhost:3030/data/catches';
let loadButton = document.querySelector('aside button.load');
let addButton = document.querySelector('#addForm button.add');

loadButton.addEventListener('click', loadCatches);

addButton.disabled = localStorage.getItem('token') == null;
addButton.addEventListener('click', addCatch);

async function addCatch(e) {
    let anglerInputElement = document.querySelector('#addForm .angler');
    let weightInputElement = document.querySelector('#addForm .weight');
    let speciesInputElement = document.querySelector('#addForm .species');
    let locationInputElement = document.querySelector('#addForm .location');
    let baitInputElement = document.querySelector('#addForm .bait');
    let captureInputElement = document.querySelector('#addForm .captureTime');

    let catchObj = {
        angler: anglerInputElement.value,
        weight: Number(weightInputElement.value),
        species: speciesInputElement.value,
        location: locationInputElement.value,
        bait: baitInputElement.value,
        captureTime: Number(captureInputElement.value)
    }
    try {
        let addResponse = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': localStorage.getItem('token')
            },
            body: JSON.stringify(catchObj)
        });
    } catch (error) {
        console.error('Adding failed!');
    }

    loadCatches();

    anglerInputElement.value = '';
    weightInputElement.value = '';
    speciesInputElement.value = '';
    locationInputElement.value = '';
    baitInputElement.value = '';
    captureInputElement.value = '';
}

async function loadCatches(e) {
    [...catchesDivElement.children].forEach(el => el.remove());
    try {
        let loadResponse = await fetch(baseUrl);
        let catchesInfo = await loadResponse.json();

        catchesInfo.forEach(c => {
            let divCatchElement = createCatchElement(c);
            catchesDivElement.appendChild(divCatchElement);
        });
    } catch (error) {
        console.error('Loading failed!');
    }
}

async function updateCatch(e) {
    let divCatchElement = e.currentTarget.parentElement;

    let anglerInputElement = divCatchElement.querySelector('.angler');
    let weightInputElement = divCatchElement.querySelector('.weight');
    let speciesInputElement = divCatchElement.querySelector('.species');
    let locationInputElement = divCatchElement.querySelector('.location');
    let baitInputElement = divCatchElement.querySelector('.bait');
    let captureInputElement = divCatchElement.querySelector('.captureTime');

    let updatedCatchObj = {
        angler: anglerInputElement.value,
        weight: Number(weightInputElement.value),
        species: speciesInputElement.value,
        location: locationInputElement.value,
        bait: baitInputElement.value,
        captureTime: Number(captureInputElement.value)
    }

    let id = divCatchElement.dataset.id;
    try {
        let updateResponse = await fetch(`${baseUrl}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': localStorage.getItem('token')
            },
            body: JSON.stringify(updatedCatchObj)
        });

        let updateResult = await updateResponse.json();
    } catch (error) {
        console.error('Updating failed!');
    }
}

async function deleteCatch(e) {
    let divCatchElement = e.currentTarget.parentElement;
    let id = divCatchElement.dataset.id;
    try {
        let deleteResponse = await fetch(`${baseUrl}/${id}`, {
            method: 'DELETE',
            headers: {
                'X-Authorization': localStorage.getItem('token')
            }
        });

        if (deleteResponse.status === 200) {
            divCatchElement.remove();
        }
    } catch (error) {
        console.error('Deleting failed!');
    }
}

function createCatchElement(catchInfo) {
    let mainDivElement = createElement('div', { class: 'catch' });

    let anglerLabelElement = createElement('label', undefined, 'Angler');
    let anglerInputElement = createElement('input', { type: 'text', class: 'angler' }, catchInfo.angler);
    let anglerHrElement = createElement('hr');

    let weightLabelElement = createElement('label', undefined, 'Weight');
    let weightInputElement = createElement('input', { type: 'number', class: 'weight' }, catchInfo.weight);
    let weightHrElement = createElement('hr');

    let speciesLabelElement = createElement('label', undefined, 'Species');
    let speciesInputElement = createElement('input', { type: 'text', class: 'species' }, catchInfo.species);
    let speciesHrElement = createElement('hr');

    let locationLabelElement = createElement('label', undefined, 'Location');
    let locationInputElement = createElement('input', { type: 'text', class: 'location' }, catchInfo.location);
    let locationHrElement = createElement('hr');

    let baitLabelElement = createElement('label', undefined, 'Bait');
    let baitInputElement = createElement('input', { type: 'text', class: 'bait' }, catchInfo.bait);
    let baitHrElement = createElement('hr');

    let captureLabelElement = createElement('label', undefined, 'Capture Time');
    let captureInputElement = createElement('input', { type: 'number', class: 'captureTime' }, catchInfo.captureTime);
    let captureHrElement = createElement('hr');

    let updateButton = createElement('button', { disabled: true, class: 'update' }, 'Update');
    updateButton.disabled = localStorage.getItem('userId') !== catchInfo._ownerId;

    updateButton.addEventListener('click', updateCatch);

    let deleteButton = createElement('button', { disabled: true, class: 'delete' }, 'Delete');
    deleteButton.disabled = localStorage.getItem('userId') !== catchInfo._ownerId;

    deleteButton.addEventListener('click', deleteCatch);

    mainDivElement.append(anglerLabelElement, anglerInputElement, anglerHrElement,
        weightLabelElement, weightInputElement, weightHrElement,
        speciesLabelElement, speciesInputElement, speciesHrElement,
        locationLabelElement, locationInputElement, locationHrElement,
        baitLabelElement, baitInputElement, baitHrElement,
        captureLabelElement, captureInputElement, captureHrElement,
        updateButton, deleteButton);

    mainDivElement.dataset.id = catchInfo._id;
    mainDivElement.dataset.ownerId = catchInfo._ownerId;

    return mainDivElement;
}

function createElement(tag, attributes, ...params) {
    let el = document.createElement(tag);
    let firstParam = params[0];

    if (params.length === 1 && typeof (firstParam) !== 'object') {
        if (tag == 'input' || tag == 'textarea') {
            el.value = firstParam;
        } else {
            el.textContent = firstParam;
        }
    } else {
        el.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            el.setAttribute(key, attributes[key]);
        });
    }

    return el;
}