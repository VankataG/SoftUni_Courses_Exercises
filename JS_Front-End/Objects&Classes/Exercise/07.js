function printOddOccurrences(array){

    let tracker = {};

    let words = array.toLowerCase().split(' ');

    for( let word of words){
        if (tracker[word] == undefined){
            tracker[word] = 0;
        }

        tracker[word]++;
    }

    let trackerArray = Object.entries(tracker);

    let result = [];
    for( let [word, count] of trackerArray){
        if (count % 2 != 0){
            result.push(word);
        }
    }

    console.log(result.join(' '));
    
}

printOddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');