const loadBtnEl = document.getElementById('btnLoad');
const phonebookUlEl = document.getElementById('phonebook');
const personInputEl = document.getElementById('person');
const phoneInputEl = document.getElementById('phone');
const createBtnEl = document.getElementById('btnCreate');

function attachEvents() {
    loadBtnEl.addEventListener('click', handleLoad);
    createBtnEl.addEventListener('click', handleCreate);
}

attachEvents();

async function handleLoad() {
    phonebookUlEl.innerHTML = '';

    const loadResp = await fetch('http://localhost:3030/jsonstore/phonebook');
    const loadData = await loadResp.json();

    const phonebookDataArr = Object.values(loadData);
    

    phonebookDataArr.forEach(n => {
        const liEl = document.createElement('li');
        liEl.textContent = `${n.person}: ${n.phone}`;

        const btnEl = document.createElement('button');
        btnEl.textContent = 'Delete';
        btnEl.addEventListener('click', async () => {
            await handleDelete(n._id);
            liEl.remove();
        });
        
        liEl.appendChild(btnEl);
        phonebookUlEl.appendChild(liEl);
    });

};

async function handleCreate(){
    const person = personInputEl.value;
    const phone = phoneInputEl.value;

    const newObj = { person, phone};

    const createResp = await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newObj)
    });


}

async function handleDelete(id){
    const deleteResp = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
        method: "DELETE",
        headers: {
            'Content-Type': 'application/json'
        }
    });

    console.log(deleteResp);
    
}