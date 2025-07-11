function solve(word, text)
{
    let textWords = text.toLowerCase().split(' ');

    if(textWords.includes(word))
        console.log(word)
    else
        console.log(`${word} not found!`);
}

solve('python',
'JavaScript is the best programming language')