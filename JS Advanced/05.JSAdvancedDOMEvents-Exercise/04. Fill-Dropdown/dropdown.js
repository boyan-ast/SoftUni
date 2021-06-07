function addItem() {
    let textInputElement = document.getElementById('newItemText');
    let valueInputElement = document.getElementById('newItemValue');

    let text = textInputElement.value;
    let value = valueInputElement.value;

    let optionElement = document.createElement('option');
    optionElement.textContent = text;
    optionElement.value = value;

    let dropdownElement = document.getElementById('menu');
    dropdownElement.appendChild(optionElement);

    textInputElement.value = '';
    valueInputElement.value = '';
}