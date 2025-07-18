document.addEventListener('DOMContentLoaded', solve);

function solve() {
    
    document.querySelector('main').addEventListener('click', (e) => {

        if (e.target.nodeName !== 'BUTTON') return;

        const profileEl = e.target.closest('.profile');
        const lockState = profileEl.querySelector('input:checked').id;

        if (lockState.includes('Lock')) return;
        
        const hiddenEl = profileEl.querySelector('.hidden-fields');

        if (hiddenEl.classList.contains('active')){
            hiddenEl.classList.remove('active');
        } else {
            hiddenEl.classList.add('active');
        }

    });
}