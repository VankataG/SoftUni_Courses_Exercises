window.addEventListener('load', addEvents);

const loadAllBtnEl = document.getElementById('load-orders');
const orderListDivEl = document.getElementById('list');
const orderBtnEl = document.getElementById('order-btn');
const editBtnEl = document.getElementById('edit-order');
const formEl = document.querySelector('div#form form');
const nameInputEl = document.getElementById('name');
const quantityInputEl = document.getElementById('quantity');
const dateInputEl = document.getElementById('date');
let currentOrderId = null;

async function addEvents(){
    loadAllBtnEl.addEventListener('click', handleLoadAll);
    orderBtnEl.addEventListener('click', async (e) => {
        e.preventDefault();
        await handleCreateOrder();
    } );
    editBtnEl.addEventListener('click', async (e) => {
        e.preventDefault();
        await handleEditOrder();
    })
}

async function handleLoadAll(){
    orderListDivEl.innerHTML = '';
    const ordersResp = await fetch('http://localhost:3030/jsonstore/orders/');
    const ordersData = await ordersResp.json();

    const ordersArr = Object.values(ordersData);
    
    ordersArr.forEach(order => {
        const name = order.name;
        const quantity = order.quantity;
        const date = order.date;

        const containerDiv = document.createElement('div');
        containerDiv.classList.add('container');

        const h2 = document.createElement('h2');
        h2.textContent = `${name}`;
        containerDiv.appendChild(h2);

        const h3Date = document.createElement('h3');
        h3Date.textContent = `${date}`;
        containerDiv.appendChild(h3Date);

        const h3Amount = document.createElement('h3');
        h3Amount.textContent = `${quantity}`;
        containerDiv.appendChild(h3Amount);

        const changeBtn = document.createElement('button');
        changeBtn.classList.add('change-btn');
        changeBtn.textContent = 'Change';
        changeBtn.addEventListener('click',() => {
            containerDiv.remove();

            nameInputEl.value = name;
            quantityInputEl.value = quantity;
            dateInputEl.value = date;
            
            orderBtnEl.disabled = true;
            editBtnEl.disabled = false;
            currentOrderId = order._id;
        });
        containerDiv.appendChild(changeBtn);

        
        const doneBtn = document.createElement('button');
        doneBtn.classList.add('done-btn');
        doneBtn.textContent = 'Done';
        doneBtn.addEventListener('click', async () => {
            const deleteResp = await fetch(`http://localhost:3030/jsonstore/orders/${order._id}`, {
                method: 'DELETE'
            });

            await handleLoadAll();
        })
        containerDiv.appendChild(doneBtn);

        orderListDivEl.appendChild(containerDiv);
    });
}

async function handleCreateOrder() {
    const name = nameInputEl.value;
    const quantity = quantityInputEl.value;
    const date = dateInputEl.value;

    if(!name || !quantity || !date) return;

    const newOrder = {name, quantity, date};

    const createOrderResp = await fetch('http://localhost:3030/jsonstore/orders/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newOrder)
    })

    formEl.reset();
    await handleLoadAll();
}

async function handleEditOrder(){
    const name = nameInputEl.value;
    const quantity = quantityInputEl.value;
    const date = dateInputEl.value;

    if(!name || !quantity || !date) return;
    const editedOrder = {
            name,
            quantity,
            date,
            _id: currentOrderId
        };

    const editOrderResp = await fetch(`http://localhost:3030/jsonstore/orders/${currentOrderId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(editedOrder)
    });

    console.log(editOrderResp);
    
    currentOrderId = null;
    formEl.reset();
    editBtnEl.disabled = true;
    orderBtnEl.disabled = false;

    await handleLoadAll();
}