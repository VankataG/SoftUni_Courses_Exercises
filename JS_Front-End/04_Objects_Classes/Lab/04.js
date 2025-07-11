function convertToJson(firstName, lastName, hairColor){
    let person = {};
    person.name = firstName;
    person.lastName = lastName;
    person.hairColor = hairColor;
    
    console.log(JSON.stringify(person))
}

convertToJson('George', 'Jones', 'Brown')