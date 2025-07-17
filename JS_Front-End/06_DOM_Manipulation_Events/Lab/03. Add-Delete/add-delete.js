function addItem() {
    const itemsUlEl = document.getElementById('items');
    const inputEl = document.getElementById('newItemText');
    
    const inputText = inputEl.value.trim();

    const newLiEl = document.createElement('li');
    newLiEl.textContent = inputText;

    const aDeleteEl = document.createElement('a')
    aDeleteEl.textContent = '[Delete]';
    aDeleteEl.href = '#';
    aDeleteEl.addEventListener('click', function (e) {
        newLiEl.remove();
    })

    newLiEl.appendChild(aDeleteEl);

    itemsUlEl.appendChild(newLiEl);

}
