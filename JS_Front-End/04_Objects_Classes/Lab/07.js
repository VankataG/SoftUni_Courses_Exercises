function printAddressBook(array){

    let addressBook = {};

    for(let address of array){
        let addressData = address.split(':');

        let name = addressData[0];
        let addressName = addressData[1];

        addressBook[name] = addressName;
    }

    

    let keys = Object.getOwnPropertyNames(addressBook);

    for(const key of keys.sort()){
        console.log(`${key} -> ${addressBook[key]}`);
        
    }
    
}

printAddressBook(
    [
        'Tim:Doe Crossing',
        'Bill:Nelson Place',
        'Peter:Carlyle Ave',
        'Bill:Ornery Rd'
]
)