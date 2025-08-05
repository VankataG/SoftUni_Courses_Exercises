window.addEventListener("load", solve);

function solve(){
    const formEl = document.querySelector('form.event-content');
    const eventInputEl = document.getElementById('event');
    const noteInputEl = document.getElementById('note');
    const dateInputEl = document.getElementById('date');
    const saveBtnEl = document.getElementById('save');

    const upcomingUlEl = document.getElementById('upcoming-list');
    const endedUlEl = document.getElementById('events-list');

    const deleteBtnEl = document.querySelector('button.btn.delete');

    saveBtnEl.addEventListener('click', handleSaveEvent);
    deleteBtnEl.addEventListener('click', () => {
        endedUlEl.innerHTML = '';
    });

    function handleSaveEvent(){
        const event = eventInputEl.value;
        const note = noteInputEl.value;
        const date = dateInputEl.value;

        if (!event || !note || !date) return;

        const li = document.createElement('li');
        li.classList.add('event-item');

        // Create container div
        const containerDiv = document.createElement('div');
        containerDiv.classList.add('event-container');

        // Create article and paragraphs
        const article = document.createElement('article');

        const pEvent = document.createElement('p');
        pEvent.textContent = `Name: ${event}`;

        const pNote = document.createElement('p');
        pNote.textContent = `Note: ${note}`;

        const pDate = document.createElement('p');
        pDate.textContent = `Date: ${date}`;

        article.appendChild(pEvent);
        article.appendChild(pNote);
        article.appendChild(pDate);

        // Create buttons container
        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');

        const editBtn = document.createElement('button');
        editBtn.classList.add('btn', 'edit');
        editBtn.textContent = 'Edit';

        const doneBtn = document.createElement('button');
        doneBtn.classList.add('btn', 'done');
        doneBtn.textContent = 'Done';

        buttonsDiv.appendChild(editBtn);
        buttonsDiv.appendChild(doneBtn);

        // Build full structure
        containerDiv.appendChild(article);
        containerDiv.appendChild(buttonsDiv);
        li.appendChild(containerDiv);

        upcomingUlEl.appendChild(li);

        editBtn.addEventListener('click', () => {
            eventInputEl.value = event;
            noteInputEl.value = note;
            dateInputEl.value = date;
            li.remove();
        });

        doneBtn.addEventListener('click', () => {
            li.remove();
            const buttonsDiv = li.querySelector('.buttons');
            buttonsDiv.remove();

            endedUlEl.appendChild(li);
        });
        formEl.reset();
    }
}

