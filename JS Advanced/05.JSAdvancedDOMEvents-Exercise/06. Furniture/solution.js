function solve() {
  let inputTextareaElement = document.querySelectorAll('#exercise > textarea')[0];
  let outputTextareaElement = document.querySelector('#exercise > textarea:nth-last-child(2)');
  let generateButtonElement = document.querySelectorAll('#exercise > button')[0];
  let buyButtonElement = document.querySelector('#exercise > button:nth-last-child(1)');
  let tbodyElement = document.querySelector('tbody');


  generateButtonElement.addEventListener('click', (e) => {
    let inputText = inputTextareaElement.value;
    let objects = JSON.parse(inputText);

    for (let obj of objects) {
      let rowElement = document.createElement('tr');

      let firstColElement = document.createElement('td');
      let imgElement = document.createElement('img');
      imgElement.setAttribute('src', `${obj.img}`);
      firstColElement.appendChild(imgElement);

      let secondColElement = document.createElement('td');
      let secondColPElement = document.createElement('p');
      secondColPElement.textContent = obj.name;
      secondColElement.appendChild(secondColPElement);

      let thirdColElement = document.createElement('td');
      let thirdColPElement = document.createElement('p');
      thirdColPElement.textContent = obj.price;
      thirdColElement.appendChild(thirdColPElement);

      let fourthColElement = document.createElement('td');
      let fourthColPElement = document.createElement('p');
      fourthColPElement.textContent = obj.decFactor;
      fourthColElement.appendChild(fourthColPElement);

      let fifthColElement = document.createElement('td');
      let fifthColInputElement = document.createElement('input');
      fifthColInputElement.setAttribute('type', 'checkbox');
      fifthColElement.appendChild(fifthColInputElement);

      rowElement.appendChild(firstColElement);
      rowElement.appendChild(secondColElement);
      rowElement.appendChild(thirdColElement);
      rowElement.appendChild(fourthColElement);
      rowElement.appendChild(fifthColElement);

      tbodyElement.appendChild(rowElement);
    }
  });

  let boughtFurniture = [];
  let totalPrice = 0;
  let decFactors = [];

  buyButtonElement.addEventListener('click', (e) => {
    let checkboxElements = document.querySelectorAll('tbody td:nth-last-child(1) input');

    for (let el of checkboxElements) {
      if (el.checked) {
        let rowElement = el.parentNode.parentNode;
        let product = rowElement.querySelector('td:nth-child(2) p').textContent;
        boughtFurniture.push(product);
        let price = Number(rowElement.querySelector('td:nth-child(3) p').textContent);
        totalPrice += price;
        let decFactor = Number(rowElement.querySelector('td:nth-child(4) p').textContent);
        decFactors.push(decFactor);
      }
    }

    outputTextareaElement.value += `Bought furniture: ${boughtFurniture.join(', ')}\n`;
    outputTextareaElement.value += `Total price: ${totalPrice.toFixed(2)}\n`;

    let avgDecFactor = decFactors.reduce((a, el) => a + el/decFactors.length, 0);

    outputTextareaElement.value += `Average decoration factor: ${avgDecFactor}`;
  });
}