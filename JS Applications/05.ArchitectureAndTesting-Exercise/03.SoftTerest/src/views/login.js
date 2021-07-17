export function setupLogin(section, navigation) {
    let formElement = section.querySelector('form');

    formElement.addEventListener('submit', loginUser);

    return showLogin;

    async function showLogin() {
        return section;
    }

    async function loginUser(e) {
        e.preventDefault();

        let formElement = e.currentTarget;

        let formData = new FormData(formElement);

        let email = formData.get('email');
        let password = formData.get('password');

        let response = await fetch('http://localhost:3030/users/login', {
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
            let loginResult = await response.json();
            sessionStorage.setItem('authToken', loginResult.accessToken);
            sessionStorage.setItem('userId', loginResult._id);

            formElement.reset();
            navigation.setUserNav();
            navigation.goTo('homepage');
        } else {
            console.error('Error!');
            return;
        }
    }
}