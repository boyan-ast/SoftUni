function encodeAndDecodeMessages() {
    let encodeButtonElement = document.querySelector('#main div button');
    let messageTextAreaElement = document.querySelector('#main div textarea');
    let resultTextAreaElement = document.querySelector('#main div:nth-child(2) textarea');
    let decodeButtonElement = document.querySelector('#main div:nth-child(2) button');

    encodeButtonElement.addEventListener('click', (e) => {
        let inputText = messageTextAreaElement.value;
        let encodedText = [...inputText].map(e => String.fromCharCode(e.charCodeAt(0) + 1)).join('');
        resultTextAreaElement.value = encodedText;

        messageTextAreaElement.value = '';
    });

    decodeButtonElement.addEventListener('click', (e) => {
        let encodedText = resultTextAreaElement.value;
        let decodedText = [...encodedText].map(e => String.fromCharCode(e.charCodeAt(0) - 1)).join('');
        resultTextAreaElement.value = decodedText;
    });
}