window.addEventListener("load", solve);

function solve() {
    const laptopInfoFormEl = document.querySelector('form.laptop-info');
    const addBtnEl = document.querySelector('#add-btn');
    const modelInputEl = document.getElementById('laptop-model');
    const storageInputEl = document.getElementById('storage');
    const priceInputEl = document.getElementById('price');
    const checkListUlEl = document.getElementById('check-list');
    const laptopListUlEl = document.getElementById('laptops-list');
    const clearBtnEl = document.querySelector('button.btn.clear');

    addBtnEl.addEventListener('click', handleAddLaptop);
    clearBtnEl.addEventListener('click', () => {
      window.location.reload();
    });

    function handleAddLaptop(){
      const model = modelInputEl.value;
      const storage = Number(storageInputEl.value);
      const price = Number(priceInputEl.value);

      if (!model || !storage || !price) return;

      const liEl = document.createElement('li');
      liEl.classList.add('laptop-item')

      const articleEl = document.createElement('article');
      const modelPEl = document.createElement('p');
      modelPEl.textContent = model;
      const storagePEl = document.createElement('p');
      storagePEl.textContent = `Memory: ${storage} TB`;
      const pricePEl = document.createElement('p');
      pricePEl.textContent = `Price: ${price}$`;

      articleEl.appendChild(modelPEl);
      articleEl.appendChild(storagePEl);
      articleEl.appendChild(pricePEl);

      liEl.appendChild(articleEl);

      const editBtnEl = document.createElement('button');
      editBtnEl.classList.add('btn', 'edit');
      editBtnEl.textContent = 'edit';

      editBtnEl.addEventListener('click', () => {
        
        modelInputEl.value = model;
        storageInputEl.value = storage;
        priceInputEl.value = price;

        liEl.remove();
        
        addBtnEl.disabled = false;
        
      });
      
      const okBtnEl = document.createElement('button');
      okBtnEl.classList.add('btn', 'ok');
      okBtnEl.textContent = 'ok';

      okBtnEl.addEventListener('click', () => {
        liEl.remove();
        const buttons = liEl.querySelectorAll('button');
        buttons.forEach(btn => btn.remove());
        laptopListUlEl.appendChild(liEl);

        addBtnEl.disabled = false;
      });

      liEl.appendChild(editBtnEl);
      liEl.appendChild(okBtnEl);
      checkListUlEl.appendChild(liEl);

      addBtnEl.disabled = true;

      laptopInfoFormEl.reset();
    }
}
  