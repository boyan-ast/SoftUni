function solve() {
    let firstButtonElement = document.querySelector('div#container button');
    let ulMoviesElement = document.querySelector('#movies ul');
    let clearButtonElement = document.querySelector('#archive>button');

    firstButtonElement.addEventListener('click', addMovie);

    function addMovie(e) {
        let nameInputElement = document.querySelector('#container input[placeholder = "Name"]');
        let hallInputElement = document.querySelector('#container input[placeholder = "Hall"]');
        let priceInputElement = document.querySelector('#container input[placeholder = "Ticket Price"]');
        let name = nameInputElement.value;
        let hall = hallInputElement.value;
        let price = priceInputElement.value;

        if (name.trim() != '' && hall.trim() != '' && price.trim() != '' && !isNaN(price)) {
            let liMovieElement = document.createElement('li');
            let spanMovieElement = document.createElement('span');
            spanMovieElement.textContent = name;
            let strongMovieElement = document.createElement('strong');
            strongMovieElement.textContent = `Hall: ${hall}`;

            liMovieElement.appendChild(spanMovieElement);
            liMovieElement.appendChild(strongMovieElement);

            let divElement = document.createElement('div');
            let strongPriceElement = document.createElement('strong');
            strongPriceElement.textContent = `${Number(price).toFixed(2)}`;
            let inputTicketsSoldElement = document.createElement('input');
            inputTicketsSoldElement['placeholder'] = 'Tickets Sold';
            let archiveButtonElement = document.createElement('button');
            archiveButtonElement.textContent = 'Archive';

            archiveButtonElement.addEventListener('click', (e) => {
                let inputElement = e.target.parentElement.children[1];
                let numberOfTickets = inputElement.value;

                if ((numberOfTickets.trim() != '' && !isNaN(Number(numberOfTickets)))) {
                    numberOfTickets = Number(numberOfTickets);
                    let totalPrice = Number(price) * numberOfTickets;

                    let archiveUlElement = document.querySelector('#archive ul');

                    let liArchiveElement = document.createElement('li');
                    let spanArchiveElement = document.createElement('span');
                    spanArchiveElement.textContent = name;
                    let strongArchiveElement = document.createElement('strong');
                    strongArchiveElement.textContent = `Total amount: ${totalPrice.toFixed(2)}`;
                    let deleteButtonElement = document.createElement('button');
                    deleteButtonElement.textContent = 'Delete';

                    deleteButtonElement.addEventListener('click', (e) => {
                        e.currentTarget.parentElement.remove();
                    });

                    liArchiveElement.appendChild(spanArchiveElement);
                    liArchiveElement.appendChild(strongArchiveElement);
                    liArchiveElement.appendChild(deleteButtonElement);

                    archiveUlElement.appendChild(liArchiveElement);

                    e.target.parentElement.parentElement.remove();
                }
            });

            divElement.appendChild(strongPriceElement);
            divElement.appendChild(inputTicketsSoldElement);
            divElement.appendChild(archiveButtonElement);

            liMovieElement.appendChild(divElement);

            ulMoviesElement.appendChild(liMovieElement);
            nameInputElement.value = '';
            hallInputElement.value = '';
            priceInputElement.value = '';
            
            e.preventDefault();
        }
    }

    clearButtonElement.addEventListener('click', (e) => {
        let allLiElements = Array.from(document.querySelectorAll('#archive ul li'));
        allLiElements.forEach(el => el.remove());
    });
}
