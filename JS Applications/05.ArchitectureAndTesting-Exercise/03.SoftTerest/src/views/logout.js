export function setupLogout(section, navigation) {
    return logout;

    async function logout() {
        let response = await fetch('http://localhost:3030/users/logout', {
            method: 'GET',
            headers:{
                'X-Authorization': sessionStorage.authToken
            }
        });

        if (response.ok) {
            sessionStorage.clear();
            navigation.setUserNav();
        } else {
            console.error('Error');
        }

        return section;
    }
}