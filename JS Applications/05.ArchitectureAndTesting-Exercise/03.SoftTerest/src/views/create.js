export function setupCreate(section, navigation) {
    let form = section.querySelector('form');
    form.addEventListener('submit', createIdea);

    return showCreate;

    async function showCreate() {
        return section;
    }

    async function createIdea(e) {
        e.preventDefault();
        let form = e.currentTarget;

        let formData = new FormData(form);

        let title = formData.get('title');
        let description = formData.get('description');
        let img = formData.get('imageURL');

        if (title.length < 6 || description.length < 10 || img.length < 5) {
            console.error('Invalid input!');
            return;
        }

        let createResponse = await fetch('http://localhost:3030/data/ideas', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': sessionStorage.authToken
            },
            body: JSON.stringify({
                title,
                description,
                img
            })
        });

        if (createResponse.ok) {
            form.reset();
            navigation.goTo('dashboard');
        }
    }
}