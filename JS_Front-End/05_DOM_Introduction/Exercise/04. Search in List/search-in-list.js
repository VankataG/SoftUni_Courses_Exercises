function solve() {
   let townsArr = document.querySelectorAll('#towns li');

   const searchText = document.getElementById('searchText').value;

   let count = 0;
   
   for (let town of townsArr) {
      if (town.textContent.includes(searchText)){
         count++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      }
   }

   let result = document.getElementById('result');

   result.textContent = `${count} matches found`;
}