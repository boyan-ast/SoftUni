function create(words) {
   let divElementsArray = words.reduce((a, el) => {
      let divElement = document.createElement('div');
      let pElement = document.createElement('p');
      pElement.textContent = el;
      pElement.style.display = 'none';

      divElement.appendChild(pElement);

      divElement.addEventListener('click', (e) => {
         e.currentTarget.firstChild.style.display = 'inline-block';
      });

      a.push(divElement);
      return a;
   }, []);

   let resultDivElement = document.getElementById('content');
   console.log(divElementsArray);
   divElementsArray.forEach(el => resultDivElement.appendChild(el));
}