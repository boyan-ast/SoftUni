window.addEventListener('load', solution);

function solution() {
  let nameInputElement = document.getElementById('fname');
  let emailInputElement = document.getElementById('email');
  let phoneInputElement = document.getElementById('phone');
  let addressInputElement = document.getElementById('address');
  let codeInputElement = document.getElementById('code');

  let sumbitButtonElement = document.getElementById('submitBTN');

  sumbitButtonElement.addEventListener('click', submitForm);

  function submitForm(e) {
    let name = nameInputElement.value;
    let email = emailInputElement.value;
    let phone = phoneInputElement.value;
    let address = addressInputElement.value;
    let code = codeInputElement.value;

    if (name !== '' && email !== '') {
      sumbitButtonElement.disabled = true;

      let editButtonElement = document.getElementById('editBTN');
      editButtonElement.disabled = false;
      let continueButtonElement = document.getElementById('continueBTN');
      continueButtonElement.disabled = false;

      let previewUlElement = document.getElementById('infoPreview');

      let nameLiElement = document.createElement('li');
      nameLiElement.textContent = `Full Name: ${name}`;
      let emailLiElement = document.createElement('li');
      emailLiElement.textContent = `Email: ${email}`;

      previewUlElement.appendChild(nameLiElement);
      previewUlElement.appendChild(emailLiElement);


      let phoneLiElement = document.createElement('li');
      phoneLiElement.textContent = `Phone Number: ${phone}`;
      previewUlElement.appendChild(phoneLiElement);


      let addressLiElement = document.createElement('li');
      addressLiElement.textContent = `Address: ${address}`;
      previewUlElement.appendChild(addressLiElement);


      let codeLiElement = document.createElement('li');
      codeLiElement.textContent = `Postal Code: ${code}`;
      previewUlElement.appendChild(codeLiElement);


      editButtonElement.addEventListener('click', (e) => {
        nameInputElement.value = name;
        emailInputElement.value = email;
        phoneInputElement.value = phone;
        addressInputElement.value = address;
        codeInputElement.value = code;

        editButtonElement.disabled = true;
        continueButtonElement.disabled = true;
        sumbitButtonElement.disabled = false;

        Array.from(previewUlElement.children).forEach(el => el.remove());
      });

      continueButtonElement.addEventListener('click', (e) => {
        let mainDivElement = document.getElementById('block');
        mainDivElement.innerHTML = '';
        //Array.from(mainDivElement.children).forEach(el => el.remove());

        let h3Element = document.createElement('h3');
        h3Element.textContent = 'Thank you for your reservation!';
        mainDivElement.appendChild(h3Element);
      });


      //in upper scope ?
      nameInputElement.value = '';
      emailInputElement.value = '';
      phoneInputElement.value = '';
      addressInputElement.value = '';
      codeInputElement.value = '';
    }
  }
}
