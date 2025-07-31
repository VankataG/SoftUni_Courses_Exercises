const sendInputEl = document.querySelector('#submit');
const refreshInputEl = document.querySelector('#refresh');

const messagesTextareaEl = document.querySelector('#messages');

const nameInputEl = document.querySelector('input[name="author"]');
const messageInputEl = document.querySelector('input[name="content"]');


function attachEvents() {
    sendInputEl.addEventListener('click', handleSend)
    refreshInputEl.addEventListener('click', handleRefresh)
}

attachEvents();

async function handleSend(){
    const newMessage = {
        author: nameInputEl.value,
        content: messageInputEl.value,
    }

    const createResp = await fetch('http://localhost:3030/jsonstore/messenger', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newMessage)
    });
    
    const createRespData = await createResp.json();

    nameInputEl.value = '';
    messageInputEl.value = '';
}

async function handleRefresh(){
    
    const refreshResp = await fetch('http://localhost:3030/jsonstore/messenger');
    const refreshData = await refreshResp.json();

    const refreshMsgArr = Object.values(refreshData);
    console.log(refreshMsgArr);
    
    let messages = [];
    refreshMsgArr.forEach(m => {
        messages.push(`${m.author}: ${m.content}`);
    });

    messagesTextareaEl.value = messages.join('\n');
    
}