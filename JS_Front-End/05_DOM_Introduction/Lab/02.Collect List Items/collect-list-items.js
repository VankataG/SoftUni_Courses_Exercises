function extractText() {
    let items = document.querySelectorAll('#items li');

    let textareaEl = document.getElementById('result');

    for (const item of items) {
        textareaEl.textContent += item.textContent + '\n';
    }
}