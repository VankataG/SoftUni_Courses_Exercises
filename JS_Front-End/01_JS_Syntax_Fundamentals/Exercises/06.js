function sumDigits(num)
{
    let result = 0;
    while (num != 0)
    {
        result += num % 10;
        num /= 10;
        num = Math.floor(num);
    }

    console.log(result);
}

sumDigits(245678);