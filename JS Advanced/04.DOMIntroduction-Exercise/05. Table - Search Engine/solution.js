function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   const rows = document.querySelectorAll('tbody tr');
   const button = document.querySelector('#searchField');

   function onClick() {
      const searchText = button.value.toLowerCase();

      for (let row of rows) {
         if (row.textContent.toLowerCase().includes(searchText)) {
            row.setAttribute('class', 'select');
         } else {
            row.removeAttribute('class');
         }
      }
   }
}