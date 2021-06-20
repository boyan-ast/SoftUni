function solve() {
   let articlesSectionElement = document.querySelector('main section:nth-child(1)');
   let authorInputElement = document.getElementById('creator');
   let titleInputElement = document.getElementById('title');
   let categoryInputElement = document.getElementById('category');
   let contentElement = document.getElementById('content');
   let createButtonElement = document.querySelector('aside section form button');

   createButtonElement.addEventListener('click', addArticle);

   function addArticle(e) {
      e.preventDefault();

      let articleElement = document.createElement('article');

      let h1Element = document.createElement('h1');
      h1Element.textContent = titleInputElement.value;

      let pCategoryElement = document.createElement('p')
      pCategoryElement.textContent = 'Category:'
      let strongCategoryElement = document.createElement('strong');
      strongCategoryElement.textContent = categoryInputElement.value;
      pCategoryElement.appendChild(strongCategoryElement);

      let pCreatorElement = document.createElement('p');
      pCreatorElement.textContent = 'Creator:';
      let strongCreatorElement = document.createElement('strong');
      strongCreatorElement.textContent = authorInputElement.value;
      pCreatorElement.appendChild(strongCreatorElement);

      let pContentElement = document.createElement('p');
      pContentElement.textContent = contentElement.value;

      let divButtonsElement = document.createElement('div');
      divButtonsElement.classList.add('buttons');
      let deleteButtonElement = document.createElement('button');
      deleteButtonElement.classList.add('btn');
      deleteButtonElement.classList.add('delete');
      deleteButtonElement.textContent = 'Delete';

      deleteButtonElement.addEventListener('click', deleteArticle);

      let archiveButtonElement = document.createElement('button');
      archiveButtonElement.classList.add('btn');
      archiveButtonElement.classList.add('archive');
      archiveButtonElement.textContent = 'Archive';

      archiveButtonElement.addEventListener('click', archiveArticle);

      divButtonsElement.appendChild(deleteButtonElement);
      divButtonsElement.appendChild(archiveButtonElement);

      articleElement.appendChild(h1Element);
      articleElement.appendChild(pCategoryElement);
      articleElement.appendChild(pCreatorElement);
      articleElement.appendChild(pContentElement);
      articleElement.appendChild(divButtonsElement);

      articlesSectionElement.appendChild(articleElement);

      authorInputElement.value = '';
      titleInputElement.value = '';
      categoryInputElement.value = '';
      contentElement.value = '';

      function archiveArticle(e) {
         let liElement = document.createElement('li');
         liElement.textContent = h1Element.textContent;

         let olArchiveElement = document.querySelector('.archive-section ol');
         olArchiveElement.appendChild(liElement);

         Array.from(olArchiveElement.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(li => olArchiveElement.appendChild(li));

         articleElement.remove();
      }

      function deleteArticle(e) {
         e.target.parentElement.parentElement.remove();
      }
   }
}
