function solve(arr)
{
    let result = [];
    arr = arr.sort((a,b) => a-b);

    while(arr.length != 0)
    {
        result.push(arr[0]);
        if (arr.length > 1)
        {
            result.push(arr[arr.length - 1]);
        arr.splice(arr.length -1,1);
        arr.splice(0,1);
        }
        else break;
    }

    return result;
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);