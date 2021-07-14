import { homePage } from './homePage.js';

export async function postMovie(e) {
    e.preventDefault();

    let formElement = e.currentTarget;

    let formData = new FormData(formElement);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    console.log(img);

    if (title == '' || description == '' || img == '') {
        console.error('Fields must be filled!');
        return;
    }

    let postResponse = await fetch('http://localhost:3030/data/movies', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify({
            title,
            description,
            img
        })
    });

    if (postResponse.status == 200) {
        formElement.reset();
        homePage();
    }
}