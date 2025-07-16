function makeDictionary(jsonArray){
    let dictionary = {};

    for (const element of jsonArray) {
        let data = JSON.parse(element);

        let key = Object.keys(data)[0];
        let value = data[key];

        dictionary[key] = value;
    }
    
    let sortedKeys = Object.keys(dictionary).sort();
    
    for (const key of sortedKeys) {
        console.log(`Term: ${key} => Definition: ${dictionary[key]}`);
    }
}

makeDictionary(
    [
        '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
        '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
        '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
        '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
        '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
);