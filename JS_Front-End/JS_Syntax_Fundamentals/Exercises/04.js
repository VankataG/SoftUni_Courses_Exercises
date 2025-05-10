function printSum(a, b)
{
    let sum = 0;
    let nums = [];
    for (let i = a; i <= b; i++)
    {
        nums.push(i);
        sum += i;
    }

    console.log(nums.join(' '));
    console.log(`Sum: ${sum}`);
}

printSum(5,10);