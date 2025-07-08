function printPhoneBook(array){

    let phoneBook = {};

    for(let person of array){
        let personData = person.split(' ');

        let name = personData[0];
        let phone = personData[1];

        phoneBook[name] = phone;
    }

    let keys = Object.getOwnPropertyNames(phoneBook);

    for(const key of keys){
        console.log(`${key} -> ${phoneBook[key]}`);
        
    }
    
}

printPhoneBook(
    [  
        'Tim 0834212554',
        'Peter 0877547887',
        'Bill 0896543112',
        'Tim 0876566344'
    ]
)