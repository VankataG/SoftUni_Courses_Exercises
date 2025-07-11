function factorialDivision(num1, num2){
    let factorial1 = findFactorial(num1);
    let factorial2 = findFactorial(num2);

    let result = factorial1 / factorial2;
    console.log(result.toFixed(2));


    function findFactorial(num){
        let factorial = 1;

        for( let i = num; i > 0; i--){
            factorial *= i;
        }

        return factorial;
    }
}

factorialDivision(5,2);