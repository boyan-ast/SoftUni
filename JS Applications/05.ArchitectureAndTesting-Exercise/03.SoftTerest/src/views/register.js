export function setupRegister(section, navigation) {
    let formElement = section.querySelector('form');

    formElement.addEventListener('submit', registerUser);

    return showRegister;

    async function showRegister() {
        return section;
    }

    async function registerUser(e) {
        e.preventDefault();

        let formElement = e.currentTarget;
        let formData = new FormData(formElement);
        let email = formData.get('email');
        let password = formData.get('password');
        let rePassword = formData.get('repeatPassword');

        if (email.length < 3 || password.length < 3 || password != rePassword) {
            console.error('Incorrect data!');
            return;
        }

        let response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email,
                password
            })
        });

        if (response.ok) {
            let userInfo = await response.json();

            sessionStorage.setItem('authToken', userInfo.accessToken);
            sessionStorage.setItem('userId', userInfo._id);

            formElement.reset();
            navigation.setUserNav();
            navigation.goTo('homepage');
        } else {
            console.error('Error!');
            return;
        }
    }
}

