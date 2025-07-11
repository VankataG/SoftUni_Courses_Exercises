function solve(text, wordToSearch)
{
    let counter = 0;
    let wordsArr = text.split(' ');

    for(let word of wordsArr)
    {
        if(word == wordToSearch)
            counter++;
    }
    
    console.log(counter);
}

solve('softuni is great place for learning new programming languages', 'softuni');