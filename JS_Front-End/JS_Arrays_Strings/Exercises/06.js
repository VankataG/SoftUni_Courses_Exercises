function solve(text)
{
    let specialWords = [];
    let textWords = text.split(' ');

    for(let word of textWords)
    {
        if (word.startsWith('#') && word.length > 1 && /^[a-zA-Z]+$/.test(word.slice(1)))
            specialWords.push(word.slice(1));
    }

    console.log(specialWords.join('\n'));
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');