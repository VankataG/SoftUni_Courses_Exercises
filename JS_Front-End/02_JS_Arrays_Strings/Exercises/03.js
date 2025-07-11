function orderNames(arr)
{
    arr = arr.sort((a, b) => a.localeCompare(b, 'en', { sensitivity: 'base' }));

    let counter = 1;
    for (let name of arr)
    {
        console.log(`${counter}.${name}`);
        counter++;
    }
}

orderNames(["John", "Bob", "Christina", "Ema"]);