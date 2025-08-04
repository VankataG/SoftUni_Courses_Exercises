window.addEventListener('load', handleEventListeners);

const loadBtnEl = document.getElementById('load-appointments');
const editBtnEl = document.getElementById('edit-appointment');
const addBtnEl = document.getElementById('add-appointment');
const appointmentsListUlEl = document.getElementById('appointments-list');

const formEl = document.querySelector('div#form form');
const modelInputEl = document.getElementById('car-model');
const serviceSelectEl = document.getElementById('car-service');
const dateInputEl = document.getElementById('date');

let currentAppId= null;

async function handleEventListeners(){
    loadBtnEl.addEventListener('click', handleLoadAppointments);
    addBtnEl.addEventListener('click', handleAddAppointment);
    editBtnEl.addEventListener('click', handleEditAppointment);
}

async function handleLoadAppointments() {
    appointmentsListUlEl.innerHTML = '';

    const appointmentsResp = await fetch('http://localhost:3030/jsonstore/appointments/');
    const appointmentsData = await appointmentsResp.json();

    const appointmentsArr = Object.values(appointmentsData);
    
    appointmentsArr.forEach(a => {
        const liEl = document.createElement('li');
        liEl.classList.add('appointment');

        const h2El = document.createElement('h2');
        h2El.textContent = a.model;
        const dateH3El = document.createElement('h3');
        dateH3El.textContent = a.date;
        const serviceH3El = document.createElement('h3');
        serviceH3El.textContent = a.service;

        liEl.appendChild(h2El);
        liEl.appendChild(dateH3El);
        liEl.appendChild(serviceH3El);

        const btnsDivEl = document.createElement('div');
        btnsDivEl.classList.add('buttons-appointment');
        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';
        changeBtnEl.addEventListener('click', () => {
            modelInputEl.value = a.model;
            serviceSelectEl.value = a.service;
            dateInputEl.value = a.date;
            currentAppId = a._id;

            editBtnEl.disabled = false;
            addBtnEl.disabled = true;
        })


        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';
        deleteBtnEl.addEventListener('click', async () => {
            await fetch(`http://localhost:3030/jsonstore/appointments/${a._id}`, {
                method: 'DELETE'
            });
            await handleLoadAppointments();
        })

        btnsDivEl.appendChild(changeBtnEl);
        btnsDivEl.appendChild(deleteBtnEl);

        liEl.appendChild(btnsDivEl);

        appointmentsListUlEl.appendChild(liEl);
    })

    editBtnEl.disabled = true;
}

async function handleAddAppointment() {
    const model = modelInputEl.value;
    const service = serviceSelectEl.value;
    const date = dateInputEl.value;

    if (!model || !service || !date) return;

    const addResp = await fetch('http://localhost:3030/jsonstore/appointments/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({model, service, date})
    });
    
    formEl.reset();

    await handleLoadAppointments();
    
}

async function handleEditAppointment(){
    const model = modelInputEl.value;
    const service = serviceSelectEl.value;
    const date = dateInputEl.value;

    if (!model || !service || !date) return;

    const editedAppointment = {model, service, date, _id: currentAppId};
    const editResp = await fetch(`http://localhost:3030/jsonstore/appointments/${currentAppId}`, {
        method: "PUT",
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(editedAppointment)
    });

    formEl.reset();
    currentAppId = null;
    await handleLoadAppointments();

    editBtnEl.disabled = true;
    addBtnEl.disabled = false;
}