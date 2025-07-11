function solve(arr, rotations)
{
    while (rotations != 0)
    {
        let removed = arr.splice(0,1)[0];

        arr.push(removed);

        rotations--;
    }

    console.log(arr.join(' '));
}

solve([32, 21, 61, 1], 4);