function addItem() {
    let inputElement = document.getElementById('newItemText');
    let inputText = inputElement.value;

    let newLiElement = document.createElement('li');
    newLiElement.textContent = inputText;

    let aElement = document.createElement('a');
    aElement.setAttribute('href', '#');
    aElement.textContent = '[Delete]';

    aElement.addEventListener('click', function(e) {
        e.currentTarget.parentNode.remove();
    });

    newLiElement.appendChild(aElement);
    document.getElementById('items').appendChild(newLiElement);
    inputElement.value = '';   
}