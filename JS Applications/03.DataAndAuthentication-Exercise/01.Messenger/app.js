function attachEvents() {
    let submitButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');
    let textareaElement = document.getElementById('messages');
    let authorInputElement = document.querySelector('input[name="author"]');
    let contentInputElement = document.querySelector('input[name="content"]');

    let baseUrl = 'http://localhost:3030/jsonstore/messenger';

    submitButton.addEventListener('click', submitMessage);
    refreshButton.addEventListener('click', showMessages);

    function submitMessage(e) {
        let author = authorInputElement.value;
        let content = contentInputElement.value;

        if (author.trim() == '' || content.trim() == '') {
            return;
        }

        let messageObj = {
            author,
            content
        };

        fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(messageObj),
        })
            .catch(error => {
                textareaElement.value = 'Error';
            });

        authorInputElement.value = '';
        contentInputElement.value = '';
    }

    function showMessages(e) {
        fetch(baseUrl)
            .then(response => response.json())
            .then(messages => {
                let messagesArr = [];

                Object.values(messages).forEach(m => {
                    messagesArr.push(`${m.author}: ${m.content}`);
                });
                
                textareaElement.value = messagesArr.join('\n');
            })
            .catch(error => {
                textareaElement.value = 'Error';
            });
    }
}

attachEvents();