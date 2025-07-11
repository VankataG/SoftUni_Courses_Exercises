function cityInfo(city){
    let keys = Object.getOwnPropertyNames(city);

    for(const key of keys){
        console.log(`${key} -> ${city[key]}`);
        
    }
}

cityInfo(
    {
        name: "Sofia",
        area: 492,
        population: 1238438,
        country: "Bulgaria",
        postCode: "1000"
    });
