function subtract() {
    const a = Number(document.getElementById('firstNumber').value);
    const b = Number(document.getElementById('secondNumber').value);


    const resultEl = document.getElementById('result');
    resultEl.textContent = a - b;
    
}