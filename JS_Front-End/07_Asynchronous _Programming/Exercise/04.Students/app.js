const submitBtnEL = document.getElementById('submit');
const tableTbodyEl = document.querySelector('#results tbody');

const formEl = document.getElementById('form');


function applyEvents(){
    window.addEventListener('DOMContentLoaded', handleSubmit)
    formEl.addEventListener('submit', async (e) => {
        e.preventDefault();
        await handleCreateSubmit();
    })
}

applyEvents();

async function handleSubmit(){
    tableTbodyEl.innerHTML = '';
    
    const studentsResp = await fetch('http://localhost:3030/jsonstore/collections/students');
    const studentsData = await studentsResp.json();

    const studentsArr = Object.values(studentsData);

    studentsArr.forEach(s => {
        const trEl = document.createElement('tr');
        const firstNameTdEl = document.createElement('td');
        firstNameTdEl.textContent = s.firstName;
        const lastNameTdEl = document.createElement('td');
        lastNameTdEl.textContent = s.lastName;
        const facNumberTdEl = document.createElement('td');
        facNumberTdEl.textContent = s.facultyNumber;
        const gradeTdEl = document.createElement('td');
        gradeTdEl.textContent = s.grade;

        trEl.append(firstNameTdEl, lastNameTdEl, facNumberTdEl, gradeTdEl);

        tableTbodyEl.appendChild(trEl);
    })
    
}

async function handleCreateSubmit() {
    if (!formEl) return;

    const firstName = formEl.querySelector('.inputs input[name="firstName"]').value;
    const lastName = formEl.querySelector('.inputs input[name="lastName"]').value;
    const facultyNumber = formEl.querySelector('.inputs input[name="facultyNumber"]').value;
    const grade = formEl.querySelector('.inputs input[name="grade"]').value;

    if (!firstName || !lastName || !facultyNumber || isNaN(grade)) {
        return;
    }

    const newStudent = {
        firstName,
        lastName,
        facultyNumber,
        grade
    }

    const studentCreateResp = await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newStudent)
    })

    console.log(studentCreateResp);
    
    formEl.reset();

    await handleSubmit();
}