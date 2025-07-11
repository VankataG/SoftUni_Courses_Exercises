function sumOddEven(num){
    let oddSum = 0;
    let evenSum = 0;

    for (let i = 0; i < num.toString().length; i++) {
        let number = (Number)(num.toString()[i]);

        if (number % 2 == 0){
            evenSum += number;
            continue;
        }
        
        oddSum += number;
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
    
}

sumOddEven(1000435)