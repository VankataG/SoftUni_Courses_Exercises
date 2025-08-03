window.addEventListener('load', appendListeners);

const loadBtnEl = document.getElementById('load-workout');
const workoutListDivEl = document.getElementById('list');
const addBtnEl = document.getElementById('add-workout');
const editBtnEl = document.getElementById('edit-workout');
const workoutInputEl = document.getElementById('workout');
const locationInputEl = document.getElementById('location');
const dateInputEl = document.getElementById('date');
let currentWorkoutId = null;

async function appendListeners(){
    loadBtnEl.addEventListener('click', handleLoadWorkouts);
    addBtnEl.addEventListener('click', handleAddWorkout);
    editBtnEl.addEventListener('click', handleEditWorkout);
}

async function handleLoadWorkouts(){
    const workoutsResp = await fetch('http://localhost:3030/jsonstore/workout/');
    const workoutsData = await workoutsResp.json();

    const workoutsArr = Object.values(workoutsData);

    
    workoutListDivEl.innerHTML = '';
    workoutsArr.forEach(w => {
        const divContainerEl = document.createElement('div');
        divContainerEl.classList.add('container');

        const h2El = document.createElement('h2');
        h2El.textContent = w.workout;
        const h3El = document.createElement('h3');
        h3El.textContent = w.date;
        const locationH3El = document.createElement('h3');
        locationH3El.textContent = w.location;

        divContainerEl.appendChild(h2El);
        divContainerEl.appendChild(h3El);
        divContainerEl.appendChild(locationH3El);

        const divBtnContainerEl = document.createElement('div');
        divBtnContainerEl.id = 'buttons-container';
        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';
        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Done';

        changeBtnEl.addEventListener('click', () => {
            divContainerEl.remove();
            workoutInputEl.value = w.workout;
            locationInputEl.value = w.location;
            dateInputEl.value = w.date;
            currentWorkoutId = w._id;

            editBtnEl.disabled = false;
            addBtnEl.disabled = true;
        });

        deleteBtnEl.addEventListener('click', async () => {
            await fetch(`http://localhost:3030/jsonstore/workout/${w._id}`, {
                method: "DELETE"
            });

            await handleLoadWorkouts();
        });

        divBtnContainerEl.appendChild(changeBtnEl);
        divBtnContainerEl.appendChild(deleteBtnEl);
        divContainerEl.appendChild(divBtnContainerEl);

        workoutListDivEl.appendChild(divContainerEl);
    })
}

async function handleAddWorkout(){
    const formEl = document.querySelector('div#form form')
    const workout = workoutInputEl.value;
    const location = locationInputEl.value;
    const date = dateInputEl.value;

    const newWorkout = { workout, location, date};

    const workoutAddResp = await fetch('http://localhost:3030/jsonstore/workout/', {
        method: "POST",
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newWorkout)
    })

    console.log(workoutAddResp);

    formEl.reset();
    await handleLoadWorkouts();
}

async function handleEditWorkout(){
    const formEl = document.querySelector('div#form form')
    const workout = workoutInputEl.value;
    const location = locationInputEl.value;
    const date = dateInputEl.value;

    const newWorkout = { workout, location, date, _id: currentWorkoutId};

    const workoutAddResp = await fetch(`http://localhost:3030/jsonstore/workout/${currentWorkoutId}`, {
        method: "PUT",
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newWorkout)
    })

    console.log(workoutAddResp);

    formEl.reset();
    await handleLoadWorkouts();
    
    editBtnEl.disabled = true;
    addBtnEl.disabled = false;

    currentWorkoutId = null;
}