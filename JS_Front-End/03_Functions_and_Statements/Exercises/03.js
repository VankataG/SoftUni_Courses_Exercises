function charsInRange(char1, char2){
    let result = [];

    let ascii1 = char1.charCodeAt();
    let ascii2 = char2.charCodeAt();

    let asciiMin = Math.min(ascii1,ascii2);
    let asciiMax = Math.max(ascii1,ascii2);

    for (let i = asciiMin + 1; i < asciiMax; i++){
        let symbol = String.fromCharCode(i);
        result.push(symbol);
    }

    console.log(result.join(' '));
    
}

charsInRange('C', '#');