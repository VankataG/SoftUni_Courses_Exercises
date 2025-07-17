function deleteByEmail() {
    const allEmailEls = document.querySelectorAll('tbody tr td:nth-child(2)');
    const inputEl = document.querySelector('input');
    const resultDivEl = document.getElementById('result');

    let isRemoved = false;
    allEmailEls.forEach(el => {
        if (el.textContent === inputEl.value){
            const parentEl = el.parentElement;
            parentEl.remove();
            isRemoved = true;
        }
    })

    if (isRemoved){
        resultDivEl.textContent = 'Deleted.'
    } else {
        resultDivEl.textContent = 'Not found.'
    }
    
}
