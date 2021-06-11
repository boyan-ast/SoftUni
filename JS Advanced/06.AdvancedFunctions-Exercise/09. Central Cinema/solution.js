function solve() {
    let nameInputElement = document.querySelector('#container input[placeholder = "Name"]');
    let hallInputElement = document.querySelector('#container input[placeholder = "Hall"]');
    let priceInputElement = document.querySelector('#container input[placeholder = "Ticket Price"]');
    let onScreenButtonElement = document.querySelector('#container button');
    let ulMoviesElement = document.querySelector('#movies ul');

    console.log(ulMoviesElement);

    onScreenButtonElement.addEventListener('click', addMovie);

    function addMovie(e) {
        let name = nameInputElement.value;
        let hall = hallInputElement.value;
        let price = priceInputElement.value;

        if (name && hall && price && !isNaN(price)) {
            let liMovieElement = document.createElement('li');
            let spanMovieElement = document.createElement('span');
            spanMovieElement.textContent = name;
            let strongMovieElement = document.createElement('strong');
            strongMovieElement.textContent = hall;

            liMovieElement.appendChild(spanMovieElement);
            liMovieElement.appendChild(strongMovieElement);

            let divElement = document.createElement('div');
            let strongPriceElement = document.createElement('strong');
            let inputTicketsSoldElement = document.createElement('input');
            inputTicketsSoldElement['placeholder'] = 'Tickets Sold';
            let archiveButtonElement = document.createElement('button');
            archiveButtonElement.textContent = 'Archive';

            divElement.appendChild(strongPriceElement);
            divElement.appendChild(inputTicketsSoldElement);
            divElement.appendChild(archiveButtonElement);

            liMovieElement.appendChild(divElement);

            ulMoviesElement.appendChild(liMovieElement);
        }

        // nameInputElement.value = '';
        // hallInputElement.value = '';
        // priceInputElement.value = '';
    }
}
