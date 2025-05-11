function solve(arr)
{
    let evenSum = 0;
    let oddSum = 0;

    for(let element of arr)
    {
        let num = Number(element)

        if(num % 2 == 0)
            evenSum += num;
        else
            oddSum += num;
    }

    let difference = evenSum - oddSum;

    console.log(difference);
}

solve([3,5,7,9]);