function lockedProfile() {
    let profilesUrl = 'http://localhost:3030/jsonstore/advanced/profiles';

    fetch(profilesUrl)
        .then(response => response.json())
        .then(profiles => {
            let mainElement = document.getElementById('main');
            Array.from(mainElement.children)[0].remove();

            Object.keys(profiles).forEach((profileKey, i) => {
                let id = i + 1;
                let username = profiles[profileKey].username;
                let email = profiles[profileKey].email;
                let age = profiles[profileKey].age;
                let profileDivElement = createProfileDiv(id, username, email, age);
                
                mainElement.appendChild(profileDivElement);                
            });
        })
        .catch(error => {
            let mainElement = document.getElementById('main');
            Array.from(mainElement.children).forEach(el => el.remove());
            mainElement.textContent = 'Error';
        });
}

function createProfileDiv(id, username, email, age) {
    let profileDiv = document.createElement('div');
    profileDiv.classList.add('profile');

    let imgElement = document.createElement('img');
    imgElement.src = './iconProfile2.png';
    imgElement.classList.add('userIcon');

    let lockLabelElement = document.createElement('label');
    lockLabelElement.textContent = 'Lock';
    let lockRadioInputElement = document.createElement('input');
    lockRadioInputElement.type = 'radio';
    lockRadioInputElement.name = `user${id}Locked`;
    lockRadioInputElement.value = 'lock';
    lockRadioInputElement.checked = true;

    let unlockLabelElement = document.createElement('label');
    unlockLabelElement.textContent = 'Unlock';
    let unlockRadioInputElement = document.createElement('input');
    unlockRadioInputElement.type = 'radio';
    unlockRadioInputElement.name = `user${id}Locked`;
    unlockRadioInputElement.value = 'unlock';

    let brElement = document.createElement('br');
    let hrElement = document.createElement('hr');

    let usernameLabelElement = document.createElement('label');
    usernameLabelElement.textContent = 'Username';
    let usernameInputElement = document.createElement('input');
    usernameInputElement.type = 'text';
    usernameInputElement.name = `user${id}Username`;
    usernameInputElement.value = username;
    usernameInputElement.disabled = true;
    usernameInputElement.readOnly = true;

    let hiddenDivElement = document.createElement('div');
    hiddenDivElement.id = `user${id}HiddenFields`;

    let secondHrElement = document.createElement('hr');
    let emailLabelElement = document.createElement('label');
    emailLabelElement.textContent = 'Email:';
    let emailInputElement = document.createElement('input');
    emailInputElement.type = 'email';
    emailInputElement.name = `user${id}Email`;
    emailInputElement.value = email;
    emailInputElement.disabled = true;
    emailInputElement.readOnly = true;
    let ageLabelElement = document.createElement('label');
    ageLabelElement.textContent = 'Age:';
    let ageInputElement = document.createElement('input');
    ageInputElement.type = 'text';
    ageInputElement.name = `user${id}Age`;
    ageInputElement.value = age;
    ageInputElement.disabled = true;
    ageInputElement.readOnly = true;

    hiddenDivElement.appendChild(secondHrElement);
    hiddenDivElement.appendChild(emailLabelElement);
    hiddenDivElement.appendChild(emailInputElement);
    hiddenDivElement.appendChild(ageLabelElement);
    hiddenDivElement.appendChild(ageInputElement);

    let buttonElement = document.createElement('button');
    buttonElement.textContent = 'Show more';

    buttonElement.addEventListener('click', showMoreInfo);

    profileDiv.appendChild(imgElement);
    profileDiv.appendChild(lockLabelElement);
    profileDiv.appendChild(lockRadioInputElement);
    profileDiv.appendChild(unlockLabelElement);
    profileDiv.appendChild(unlockRadioInputElement);
    profileDiv.appendChild(brElement);
    profileDiv.appendChild(hrElement);
    profileDiv.appendChild(usernameLabelElement);
    profileDiv.appendChild(usernameInputElement);
    profileDiv.appendChild(hiddenDivElement);
    profileDiv.appendChild(buttonElement);

    return profileDiv;
}

function showMoreInfo(e) {
    let profileDivElement = e.currentTarget.parentElement;
    let lockRadioElement = profileDivElement.querySelector('input[value="lock"]');
    
    if (lockRadioElement.checked) {
        return;
    }
    
    let hiddenDivElement = e.currentTarget.previousElementSibling;

    if (hiddenDivElement.style.display !== 'block') {
        hiddenDivElement.style.display = 'block';
        e.currentTarget.textContent = 'Hide it';
    } else {
        hiddenDivElement.style.display = 'none';
        e.currentTarget.textContent = 'Show more';
    }
}