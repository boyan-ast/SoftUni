function validate() {
    let usernameElement = document.getElementById('username');
    let emailElement = document.getElementById('email');
    let passwordElement = document.getElementById('password');
    let confirmPasswordElement = document.getElementById('confirm-password');
    let companyCheckboxElement = document.getElementById('company');
    let companyInfoFieldElement = document.getElementById('companyInfo');
    let companyNumberElement = document.getElementById('companyNumber');
    let submitButtonElement = document.getElementById('submit');
    let validDivElement = document.getElementById('valid');

    let isValidForm = true;
    let isValidName = true;
    let isValidEmail = true;
    let isValidPassword = true;
    let isValidCompany = true;

    submitButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let username = usernameElement.value;
        let email = emailElement.value;
        let password = passwordElement.value;
        let confirmPassoword = confirmPasswordElement.value;

        if (!validateUsername(username)) {
            usernameElement.removeAttribute('style');
            usernameElement.style.borderColor = 'red';
            isValidName = false;
        } else {
            usernameElement.style.border = 'none';
            isValidName = true;
        }

        if (!validateEmail(email)) {
            emailElement.removeAttribute('style');
            emailElement.style.borderColor = 'red';
            isValidEmail = false;
        } else {
            emailElement.style.border = 'none';
            isValidEmail = true;
        }

        if (!validatePassword(password)) {
            passwordElement.removeAttribute('style');
            passwordElement.style.borderColor = 'red';
            isValidPassword = false;
        } else {
            passwordElement.style.border = 'none';
            isValidPassword = true;
        }
        
        if (!validatePassword(confirmPassoword) || confirmPassoword !== password) {
            confirmPasswordElement.removeAttribute('style');
            confirmPasswordElement.style.borderColor = 'red';
            passwordElement.removeAttribute('style');
            passwordElement.style.borderColor = 'red';
            isValidPassword = false;
        } else {
            confirmPasswordElement.style.border = 'none';
            passwordElement.style.border = 'none';
            isValidPassword = true;
        }

        if (companyCheckboxElement.checked) {
            let companyNumber = companyNumberElement.value;

            if (!validateCompany(companyNumber)) {
                companyNumberElement.removeAttribute('style');
                companyNumberElement.style.borderColor = 'red';
                isValidCompany = false;
            } else {
                companyNumberElement.style.border = 'none';
                isValidCompany = true;
            }
        }

        isValidForm = isValidName && isValidEmail && isValidPassword && isValidCompany;

        if (isValidForm) {
            validDivElement.style.display = 'block';
        } else {
            validDivElement.style.display = 'none';
        }
    });

    companyCheckboxElement.addEventListener('change', (e) => {
        if (companyCheckboxElement.checked) {
            companyInfoFieldElement.style.display = 'block';
        } else {
            companyInfoFieldElement.style.display = 'none';
        }
    });

    function validateUsername(username) {
        let validUsernameRegex = /^[a-zA-Z0-9]{3,20}$/;
        return validUsernameRegex.test(username);
    }

    function validateEmail(email) {
        let validEmailRegex = /^[^@.]+@[^@]*\.[^@]*$/;
        return validEmailRegex.test(email);
    }

    function validatePassword(password) {
        let validPasswordRegex = /^[\w]{5,15}$/;
        return validPasswordRegex.test(password);
    }

    function validateCompany(companyNumber) {
        return Number(companyNumber) >= 1000 && Number(companyNumber) <= 9999;
    }
}
