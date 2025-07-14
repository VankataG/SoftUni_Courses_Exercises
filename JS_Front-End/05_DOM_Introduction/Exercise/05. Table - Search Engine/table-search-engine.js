function solve() {
   const rows = document.querySelectorAll('tbody tr');

   rows.forEach(row => row.classList.remove('select'));


   const searchInputEl = document.getElementById('searchField');
   const searchText = searchInputEl.value.toLowerCase();
   for (const row of rows) {
      const cols = row.children;
      
      for (const col of cols) {
         
         if (col.textContent.toLowerCase().includes(searchText) && searchText != '')
         {
            row.classList.add('select');
         }
      }
   }

   searchInputEl.value = '';
}