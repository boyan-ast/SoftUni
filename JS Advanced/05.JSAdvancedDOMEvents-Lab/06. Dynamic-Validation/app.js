function validate() {
    let emailElement = document.getElementById('email');
    let email = emailElement.textContent;

    emailElement.addEventListener('change', (e) => {
        if(!isValidEmail(e.target.value)) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    });

    console.log(isValidEmail(email));

    function isValidEmail (input) {
        const regex = /\w+@\w+\.\w+/gm;
        return regex.test(input);
    }
}