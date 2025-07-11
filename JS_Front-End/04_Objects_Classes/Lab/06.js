function printSuccessMeetings(array){
    
    let meetings = {};

    for(let meeting of array){

        let meetingData = meeting.split(' ');
        let weekday = meetingData[0];
        let name = meetingData[1];

        if(meetings[weekday] != undefined){
            console.log(`Conflict on ${weekday}!`);
        }
        else{
            console.log(`Scheduled for ${weekday}`);
            meetings[weekday] = name;
        }
    }


    let keys = Object.getOwnPropertyNames(meetings);

    for (let key of keys){
        console.log(`${key} -> ${meetings[key]}`)
    }
}

printSuccessMeetings(
    [
        'Monday Peter',
        'Wednesday Bill',
        'Monday Tim',
        'Friday Tim'
    ]
)