function roadRadar(speed, area)
{
    const motorwayLimit = 130;
    const interstateLimit = 90;
    const cityLimit = 50;
    const residentialLimit = 20;

    let limit;
    switch(area)
    {
        case "motorway": 
            limit = motorwayLimit;
            break;
        case "interstate":
            limit = interstateLimit;
            break;
        case "city":
            limit = cityLimit;
            break;
        case "residential":
            limit = residentialLimit;
            break;
    }

    if (speed <= limit)
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    else
    {
        let difference = speed - limit;
        let status;
        if (difference <= 20)
            status = 'speeding';
        else if (difference <= 40)
            status = 'excessive speeding';
        else
            status = 'reckless driving';


        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}

roadRadar(40, 'city');