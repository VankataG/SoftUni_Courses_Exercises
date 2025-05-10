function vacation(peopleCount, groupType, day)
{
    let price;
    let total;

    if (groupType == 'Students')
    {
        switch(day)
        {
            case 'Friday':
                price = 8.45;
                break;
            case 'Saturday':
                price = 9.80;
                break;
            case 'Sunday':
                price = 10.46;
                break;
        }
        
        total = peopleCount * price;

        if (peopleCount >= 30)
        {
            total *= 0.85;
        }
    }
    else if (groupType == "Business")
    {
        switch(day)
        {
            case 'Friday':
                price = 10.90;
                break;
            case 'Saturday':
                price = 15.60;
                break;
            case 'Sunday':
                price = 16;
                break;
        }

        if (peopleCount >= 100)
            peopleCount -= 10;

        total = peopleCount * price;
    }
    else if (groupType == 'Regular')
    {
        switch(day)
        {
            case 'Friday':
                price = 15;
                break;
            case 'Saturday':
                price = 20;
                break;
            case 'Sunday':
                price = 22.50;
                break;
        }

        total = peopleCount * price;

        if (peopleCount >= 10 & peopleCount <= 20)
            total *= 0.95;
    }

    console.log(`Total price: ${total.toFixed(2)}`);
}

vacation(40, 'Regular', 'Saturday');