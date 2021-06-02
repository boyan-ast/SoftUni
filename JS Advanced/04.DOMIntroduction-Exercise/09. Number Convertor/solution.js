function solve() {
    const selectMenuElement = document.getElementById('selectMenuTo');
    const binaryOptionElement = document.createElement('option');
    const hexadecimalOptionElement = document.createElement('option');

    binaryOptionElement.textContent = 'Binary';
    binaryOptionElement.value = 'binary';

    hexadecimalOptionElement.textContent = 'Hexadecimal';
    hexadecimalOptionElement.value = 'hexadecimal';

    selectMenuElement.appendChild(binaryOptionElement);
    selectMenuElement.appendChild(hexadecimalOptionElement);

    const selectMap = {
        'binary': num => num.toString(2),
        'hexadecimal': num => num.toString(16).toUpperCase()  
    }

    const convertButton = document.querySelector('#container>button');

    convertButton.addEventListener('click', (event) => {
        const inputDataElement = document.getElementById('input');
        const outputDataElement = document.getElementById('result');

        outputDataElement.value = selectMap[selectMenuElement.value](Number(inputDataElement.value));
    });
}