function solve() {
  const text = document.getElementById('input').value;
  const outputEl = document.getElementById('output');
  const sentences = text.split('.').filter(s => s.length > 0);

  let paragraph = '';
  for (let i = 0; i < sentences.length; i++){
    const sentence = sentences[i].trim();
    paragraph += sentence + '.';

    if ((i + 1) % 3 === 0 || i === sentences.length - 1){
      outputEl.innerHTML += `<p>${paragraph}</p>`;
      paragraph = '';
    }
  }
}