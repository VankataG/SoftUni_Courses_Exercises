function isValidPassword(password){
    let isValid = true;

    isLengthValid(password);

    let passArr = password.split('');
    let digitCount = 0;
    let invalidChar = false;
    for(let char of passArr){
        

        if(isDigit(char)){
            digitCount++;
        }
        else if (isLetter(char)){
            continue
        }
        else{
            invalidChar = true;
        }
    }    

    if (invalidChar){
        console.log('Password must consist only of letters and digits')
        isValid = false;
    }
    
    if(digitCount < 2){
        console.log('Password must have at least 2 digits')
        isValid = false;
    }


    if (isValid)
        console.log('Password is valid');
        

    function isLengthValid(password){
        if (password.length < 6 || password.length > 10){
        isValid = false;
        console.log('Password must be between 6 and 10 characters')
        }
    }

    function isLetter(char) {
        return /^[a-zA-Z]$/.test(char);
    }

    function isDigit(char) {
        return !isNaN(parseInt(char));
    }
}

isValidPassword('logIn');