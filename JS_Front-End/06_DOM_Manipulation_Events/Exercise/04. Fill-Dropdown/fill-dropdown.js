document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const selectMenuEl = document.getElementById('menu');
    
    document.querySelector('form').addEventListener('submit', (e) => {
        e.preventDefault();

        const textInput = e.target.querySelector('#newItemText').value;
        const valueInput = e.target.querySelector('#newItemValue').value;

        if (textInput == '' || valueInput == '') return;
        
        const newOption = document.createElement('option');
        newOption.textContent = textInput;
        newOption.value = valueInput;

        selectMenuEl.appendChild(newOption);

        e.target.reset();
    })
}