document.addEventListener('DOMContentLoaded', focused);

function focused() {
    const divEls = document.getElementsByClassName('panel');

    Array.from(divEls).forEach(divEl => {
        const divInputEl = divEl.lastElementChild;

        if (divInputEl){
            divInputEl.addEventListener('focus', () => {
                divEl.classList.add('focused');
            });
            divInputEl.addEventListener('blur', () => {
                divEl.classList.remove('focused');
            });
        }
    });
}
