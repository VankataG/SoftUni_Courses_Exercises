function editElement(htmlEl, match, replacer) {
    let text = htmlEl.textContent;
    htmlEl.textContent = text.replaceAll(match, replacer)
}