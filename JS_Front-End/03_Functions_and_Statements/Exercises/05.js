function arePalindromes(array){

    for (let num of array){
        console.log(isPalindrome(num));
          
    }

    function isPalindrome(num){
        let numString = String(num);
        let reverseNum = numString.split('').reverse().join('');

        return reverseNum === numString;
    }
}

arePalindromes([123,323,421,121])