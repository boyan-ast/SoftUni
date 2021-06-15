function validate() {
    let emailInputElement = document.getElementById('email');
    let validEmailRegex = /^[a-z]+@[a-z]+\.[a-z]+$/;

    emailInputElement.addEventListener('change', () => {
        let email = emailInputElement.value;
        console.log(validEmailRegex.test(email));
        if (!validEmailRegex.test(email)) {
            emailInputElement.classList.add('error');
        } else {
            emailInputElement.classList.remove('error');
        }
    });
}