function cookingNums(num, ...operationList)
{
    for (let operation of operationList)
    {
        switch(operation)
        {
            case 'chop':
                num /=2;
            break;
            case 'dice':
                 num = Math.sqrt(num);
            break;
            case 'spice':
                num++;
            break;
            case 'bake':
                num *= 3;
            break;
            case 'fillet':
                num *= 0.8;
            break;
        }

        console.log(num);
    }
}

cookingNums('32', 'chop', 'chop', 'chop', 'chop', 'chop');