function convertToObj(inputJson){
    let person = JSON.parse(inputJson);

    let keys = Object.getOwnPropertyNames(person);

    for(const key of keys){
        console.log(`${key}: ${person[key]}`);
        
    }

}

convertToObj('{"name": "George", "age": 40, "town": "Sofia"}')