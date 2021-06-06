function deleteByEmail() {
    let inputElement = document.querySelector('input[name="email"]');
    let inputText = inputElement.value;

    let emailElements = document.querySelectorAll('tbody > tr > td:nth-child(2)');

    let isFound = false;

    for (let cell of emailElements) {
        if (cell.textContent == inputText) {
            isFound = true;
            cell.parentNode.remove();
            break;
        }
    }

    let logElement = document.getElementById('result');

    logElement.textContent = isFound ? 'Deleted' : 'Not found.';

    inputElement.value = '';    
}