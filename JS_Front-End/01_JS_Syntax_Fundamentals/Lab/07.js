function ticketPrice(dayType, age){
    let price;

    switch (dayType){
        case 'Weekday':
            if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                price = '12$';
            else if (age > 18 && age <= 64)
                price = '18$';
            else
                price = 'Error!'
            break;

        case 'Weekend':
            if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                price = '15$';
            else if (age > 18 && age <= 64)
                price = '20$';
            else
                price = 'Error!'
            break;

        case 'Holiday':
            if (age >= 0 && age <= 18)
                price = '5$';
             else if (age > 18 && age <= 64)
                price = '12$';
            else if (age > 64 && age <= 122)
                price = '10$';
            else
                price = 'Error!'
            break;
    }

    console.log(price);
}

ticketPrice('Holiday', 15);