document.addEventListener('DOMContentLoaded', solve);

function solve() {
   const formEl = document.getElementById('task-input');
   const resultDivEl = document.getElementById('content');

   formEl.addEventListener('submit', handleSubmitForm)

   function handleSubmitForm(e){
      e.preventDefault();
      const inputEl = formEl.querySelector('input:nth-child(1)');

      const inputText = inputEl.value;
      
      const inputTextArr = inputText.split(', ');

      for (const el of inputTextArr) {
         const sectionEl = document.createElement('div');
         

         const pHiddenEl = document.createElement('p');
         pHiddenEl.textContent = el;
         pHiddenEl.style.display = 'none';

         sectionEl.appendChild(pHiddenEl);

         sectionEl.addEventListener('click', handleClick)
         
         resultDivEl.appendChild(sectionEl);

         function handleClick(){
            pHiddenEl.style.display = 'inline';
         }
      }
   }
}