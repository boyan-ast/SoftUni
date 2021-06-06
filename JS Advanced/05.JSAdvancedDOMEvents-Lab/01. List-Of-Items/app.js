function addItem() {
    let inputElement = document.getElementById('newItemText');
    let inputText = inputElement.value;    
    let newLiElement = document.createElement('li');
    newLiElement.textContent = inputText;

    let ulElement = document.getElementById('items');
    ulElement.appendChild(newLiElement);
    inputElement.value = '';
}