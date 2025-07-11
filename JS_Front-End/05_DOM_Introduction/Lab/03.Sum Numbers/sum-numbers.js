function calc() {
    const num1 = Number(document.getElementById('num1').value);
    const num2 = Number(document.getElementById('num2').value);

    let resultEl = document.getElementById('sum');

    let result = num1 + num2;

    resultEl.value = result;
    
}