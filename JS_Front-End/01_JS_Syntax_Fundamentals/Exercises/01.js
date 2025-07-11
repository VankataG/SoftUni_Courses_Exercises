function determineAge(num)
{
    let result;
    if (num < 0)
        result = 'out of bounds';
    else if (num <=2)
        result = 'baby';
    else if (num <= 13)
        result = 'child';
    else if (num <= 19)
        result = 'teenager';
    else if (num <= 65)
        result = 'adult';
    else if (num > 65)
        result = 'elder';
    
    console.log(result);
}

determineAge(-1);