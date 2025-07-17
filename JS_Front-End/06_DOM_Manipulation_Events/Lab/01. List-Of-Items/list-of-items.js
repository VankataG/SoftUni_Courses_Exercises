function addItem() {
    const itemsUlEl = document.getElementById('items');
    const inputEl = document.getElementById('newItemText');
    
    const inputText = inputEl.value.trim();

    const newLiEl = document.createElement('li');
    newLiEl.textContent = inputText;

    itemsUlEl.appendChild(newLiEl);

}
