window.addEventListener("load", solve);

function solve() {
  const formEl = document.querySelector('.registerEvent');
  const nextBtnEl = document.querySelector('#next-btn');
  const emailInputEl = document.getElementById('email');
  const eventInputEl = document.getElementById('event');
  const locationInputEl = document.getElementById('location');
  const previewUlEl = document.getElementById('preview-list');

 

  nextBtnEl.addEventListener('click', (e) => {
    e.preventDefault();
    handleNextBtn();
  });


  function handleNextBtn(){
    const email = emailInputEl.value;
    const event = eventInputEl.value;
    const location = locationInputEl.value;

    if(!email || !event || !location){
      return;
    }
    const liEl = document.createElement('li');
    liEl.classList.add('application');

    const articleEl = document.createElement('article');

    const h4El = document.createElement('h4');
    h4El.textContent = email;

    const eventPEl = document.createElement('p');
    const eventStrongEl = document.createElement('strong');
    eventStrongEl.textContent = "Event:";
    const eventBrEl = document.createElement('br');
    
    eventPEl.appendChild(eventStrongEl);
    eventPEl.appendChild(eventBrEl);
    eventPEl.appendChild(document.createTextNode(`${event}`))   

    
    const locationPEl = document.createElement('p');
    const locationStrongEl = document.createElement('strong');
    locationStrongEl.textContent = "Location:";
    const locationBrEl = document.createElement('br');
  
    locationPEl.append(locationStrongEl, locationBrEl, document.createTextNode(`${location}`));
    

    articleEl.append(h4El, eventPEl, locationPEl);

    liEl.append(articleEl);

    const editBtnEl = document.createElement('button');
    editBtnEl.classList.add('action-btn', 'edit');
    editBtnEl.textContent = "edit";
    const applyBtnEl = document.createElement('button');
    applyBtnEl.classList.add('action-btn', 'apply');
    applyBtnEl.textContent = "apply";

    liEl.append(editBtnEl, applyBtnEl);

    previewUlEl.append(liEl);

    formEl.reset();
    nextBtnEl.disabled = true;

    editBtnEl.addEventListener('click', () => {
      emailInputEl.value = email;
      eventInputEl.value = event;
      locationInputEl.value = location;

      nextBtnEl.disabled = false;

      previewUlEl.removeChild(liEl);
    });

    applyBtnEl.addEventListener('click', () => {
      previewUlEl.removeChild(liEl);

      const buttons = liEl.querySelectorAll('button');
      buttons.forEach(btn => btn.remove());

      const eventUlEl = document.getElementById('event-list');
      eventUlEl.appendChild(liEl);

      nextBtnEl.disabled = false;
    });
  }
    
}
