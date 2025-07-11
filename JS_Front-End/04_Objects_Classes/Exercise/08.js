function parkingPreview(array){

    let parkingLot = [];

    for (let element of array){
        let data = element.split(', ');
        let action = data[0];
        let number = data[1];

        if(action == 'IN'){
            parkingLot.push(number);
        }
        else if(action == 'OUT'){
            let index = parkingLot.indexOf(number);

            if (index !== -1) {
                    parkingLot.splice(index, 1);
            }

        }
    }

    if(parkingLot.length <= 0){
        console.log('Parking Lot is Empty');
    }
    else{
        parkingLot.sort().forEach(p => console.log(p));
    }
}

parkingPreview(
    [
        'IN, CA2844AA',
        'IN, CA1234TA',
        'OUT, CA2844AA',
        'IN, CA9999TT',
        'IN, CA2866HI',
        'OUT, CA1234TA',
        'IN, CA2844AA',
        'OUT, CA2866HI',
        'IN, CA9876HH',
        'IN, CA2822UU'
    ]
)