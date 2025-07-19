document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('form#input').addEventListener('submit', (e) => {
      e.preventDefault();

      const inputJson = e.target.querySelector('textarea').value;
      const inputObjArr = JSON.parse(inputJson);

      inputObjArr.forEach(obj => {
          const newFurnitureTrEl = createNewFurnitureRow(obj.img, obj.name, obj.price, obj.decFactor);

          document.querySelector('table tbody').appendChild(newFurnitureTrEl);
          
      });
      
    })

    document.querySelector('#shop').addEventListener('submit', (e) => {
      e.preventDefault();

      const resultTextareaEl = e.target.querySelector('textarea');
      
      const checkedFurnitures = e.target.querySelectorAll('tbody tr td input:checked');

      let checkedFurniteNames = [];
      let totalPrice = 0;
      let totalDecFactor = 0;

      checkedFurnitures.forEach(furniture => {
          const checkedRow = furniture.closest('tr');

          const rowData = checkedRow.querySelectorAll('p');
          const name = rowData[0].textContent;
          const price = Number(rowData[1].textContent);
          const decFactor = Number(rowData[2].textContent);

          checkedFurniteNames.push(name);
          totalPrice += price;
          totalDecFactor += decFactor;
      })

      console.log(`${checkedFurniteNames}  ${totalPrice}  ${totalDecFactor}`);

      resultTextareaEl.value += `Bought furniture: ${checkedFurniteNames.join(', ')}\n`;
      resultTextareaEl.value += `Total price: ${totalPrice}\n`;
      resultTextareaEl.value += `Average decoration factor: ${totalDecFactor / checkedFurniteNames.length}`;
    })



    function createNewFurnitureRow(imageUrl, name, price, decFactor){
          
          const newFurnitureTrEl = document.createElement('tr');
          newFurnitureTrEl.innerHTML = `
          <td><img src="${imageUrl}"></td>
          <td><p>${name}</p></td>
          <td><p>${price}</p></td>
          <td><p>${decFactor}</p></td>
          <td><input type="checkbox" /></td>
          `;

        return newFurnitureTrEl;
    }
}