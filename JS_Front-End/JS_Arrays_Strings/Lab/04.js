function solve(str, startIndex, count)
{
    let result = "";
    for(let i = 1; i <= count; i++)
    {
        result += str[startIndex];  
        startIndex++;
    }

    console.log(result);
}

solve('SkipWord', 4, 7);