function countWords(input){
    let wordsToFind = input[0].split(' ');
    let tracker = {};

    for(let word of wordsToFind){
        tracker[word] = 0;
    }


    for(let word of input){

        if(wordsToFind.includes(word)){
            tracker[word]++;
        }
    }

    let sortedTracker = Object.entries(tracker).sort((a,b) => b[1] - a[1])
    
    for( let [word, count] of sortedTracker){
        console.log(`${word} - ${count}`);
    }
}

countWords(
    [
        'this sentence', 
        'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
)