function solve(text)
{
    let result = [];
    let word = '';
    for(let i = 0; i < text.length; i++)
    {
        if(text[i] == text[i].toUpperCase() && i != 0)
        {
            result.push(word);
            word = '';
        }

        word += text[i];

        if(i == text.length - 1)
            result.push(word);
    }

    console.log(result.join(', '));
}

solveRegex('HoldTheDoor');