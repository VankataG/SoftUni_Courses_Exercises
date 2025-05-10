function sameNums(num)
{
    let sum = 0;
    let areSame = true;
    let checker = num % 10;
    while (num != 0)
    {
        let lastDigit = num % 10;
        num /= 10;
        num = Math.floor(num);
        sum += lastDigit;
        if (lastDigit != checker && areSame)
            areSame = false;
    }

    console.log(areSame);
    console.log(sum);
}

sameNums(22222);