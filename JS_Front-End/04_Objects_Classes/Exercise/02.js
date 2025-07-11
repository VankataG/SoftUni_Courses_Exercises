function towns(array){
    let towns = [];

    for( let element of array){
        let townData = element.split(' | ');

        let town = townData[0];
        let latitude = Number(townData[1]).toFixed(2);
        let longitude = Number(townData[2]).toFixed(2);

        towns.push({town, latitude, longitude});
    }
    for (let town of towns){
        console.log(town);
    }
}

towns(
    [
        'Sofia | 42.696552 | 23.32601',
        'Beijing | 39.913818 | 116.363625'
    ]
)