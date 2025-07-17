document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const pattern = /[a-z]+@[a-z]+\.[a-z]/;
    const emailInputEl = document.getElementById('email');

    emailInputEl.addEventListener('change', handleInputChange)



    function handleInputChange(){
        const emailInput = emailInputEl.value;

        if (pattern.test(emailInput)){
            emailInputEl.classList.remove('error');
        } else {
            emailInputEl.classList.add('error');
        }
    }
}
