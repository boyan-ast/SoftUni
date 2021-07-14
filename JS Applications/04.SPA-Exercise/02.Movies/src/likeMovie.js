
export async function likeMovie(e) {
    e.preventDefault();

    let movieDetailsElement = document.querySelector('section.movie-details');
    let movieId = movieDetailsElement.dataset.id;
    let userId = localStorage.getItem('id');

    let getMovovieresponse = await fetch(`http://localhost:3030/data/movies/${movieId}`);
    let movieDetails = await getMovovieresponse.json();

    let userLikesResponse = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
    let userLikes = await userLikesResponse.json();

    if (userLikes.length > 0) {
        console.error('You already liked the movie!');
        return;
    }

    let response = await fetch(`http://localhost:3030/data/likes`, {
        method: 'POST',
        headers: { 
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify({
            userId,
            movieId
        })
    });

    let numberOfLikesResponse = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
    let likesSpanElement = document.querySelector('span.enrolled-span');
    let likes = await numberOfLikesResponse.json();
    likesSpanElement.textContent = `Liked ${likes}`;
}