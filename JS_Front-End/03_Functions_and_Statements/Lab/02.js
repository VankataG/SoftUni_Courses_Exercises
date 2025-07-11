function power(number, power)
{
    let originalNum = number;
    for(let i = 1; i < power; i++)
    {
        
        number *= originalNum;
    }

    console.log(number);
}

power(2,8);