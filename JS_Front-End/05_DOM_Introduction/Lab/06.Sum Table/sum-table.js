function sumTable() {
    const costEls = document.querySelectorAll('tbody tr td:nth-child(2)');

    const costArr = Array.from(costEls);

    const resultEl = costArr.pop();

    let result = 0;

    for (const element of costArr) {
        result += Number(element.textContent);
    }

    resultEl.textContent = result;
}