function solve(words, text)
{
    let wordsArr = words.split(', ');
    let textArr = text.split(' ');

    for(let i = 0; i < textArr.length; i++)
    {
        if(textArr[i].startsWith('*'))
        {
            textArr[i] = wordsArr.find(w => w.length == textArr[i].length)
        }
    }

    console.log(textArr.join(' '));
}

solve('great', 'softuni is ***** place for learning new programming languages');