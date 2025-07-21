document.addEventListener('DOMContentLoaded', solve);

function solve() {
  const resultDivEl = document.getElementById('results');
  
  const questionEls = document.querySelectorAll('section.question');

  let rightAnswers = 0;
  let currentQuestionIndex = 0;

  const correctAnswers = [
    'onclick',
    'JSON.stringify()',
    'A programming API for HTML and XML documents'
  ];

    document.querySelector('main').addEventListener('click', (e) => {
        e.preventDefault();

        if (!e.target.classList.contains('quiz-answer')) return;

        if (e.target.textContent === correctAnswers[currentQuestionIndex]) rightAnswers++;

        questionEls[currentQuestionIndex].classList.add('hidden');
        
        currentQuestionIndex++;

        if (currentQuestionIndex < questionEls.length){
          questionEls[currentQuestionIndex].classList.remove('hidden');
        } else {

          if (rightAnswers === 3){
            resultDivEl.textContent = 'You are recognized as top JavaScript fan!';
          } else if (rightAnswers === 1){
            resultDivEl.textContent = `You have ${rightAnswers} right answer`;
          } else {
            resultDivEl.textContent = `You have ${rightAnswers} right answers`;
          }

        }

    })
}