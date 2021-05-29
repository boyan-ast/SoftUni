function search() {
   const towns = Array.from(document.querySelectorAll('ul#towns>li'));
   const selectedTown = document.querySelector('#searchText').value;

   let count = 0;

   for (let town of towns) {
      if (town.textContent.includes(selectedTown)) {
         town.innerHTML = `<bold><u>${town.textContent}</u></bold>`;
         count++;
      }
   }

   document.getElementById('result').textContent = `${count} matches found`;
}
