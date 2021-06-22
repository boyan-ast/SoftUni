function solution() {
    let inputGiftElement = document.querySelector('.container .card:nth-child(1) div input');
    let buttonElement = document.querySelector('.container .card:nth-child(1) div button');

    buttonElement.addEventListener('click', addGiftToList);

    function addGiftToList(e) {
        let liElement = document.createElement('li');
        liElement.classList.add('gift');
        liElement.textContent = inputGiftElement.value;

        let sendButtonElement = document.createElement('button');
        sendButtonElement.classList.add('sendButton');
        sendButtonElement.textContent = 'Send';

        sendButtonElement.addEventListener('click', sendGift);

        let discardButtonElement = document.createElement('button');
        discardButtonElement.classList.add('discardButton');
        discardButtonElement.textContent = 'Discard';

        discardButtonElement.addEventListener('click', discardGift);

        liElement.appendChild(sendButtonElement);
        liElement.appendChild(discardButtonElement);

        let ulListGiftsElement = document.querySelector('.container .card:nth-child(2) ul');
        ulListGiftsElement.appendChild(liElement);

        Array.from(ulListGiftsElement.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(el => ulListGiftsElement.appendChild(el));

        function sendGift(e) {
            let ulSentGiftsElement = document.querySelector('.container .card:nth-child(3) ul');
            [...liElement.querySelectorAll('button')].forEach(b => b.remove());
            ulSentGiftsElement.appendChild(liElement);
        }

        function discardGift(e) {
            let ulDiscardedGiftsElement = document.querySelector('.container .card:nth-child(4) ul');
            [...liElement.querySelectorAll('button')].forEach(b => b.remove());
            ulDiscardedGiftsElement.appendChild(liElement);
        }

        inputGiftElement.value = '';
    }
}