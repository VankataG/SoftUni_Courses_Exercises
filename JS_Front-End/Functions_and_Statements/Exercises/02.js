function addSubtract(a,b,c){
    function sum(a,b){
        return a + b;
    }

    function subtract(a,b){
        return a - b;
    }
    
    let result = subtract(sum(a,b),c);
    console.log(result);
}



addSubtract(42,58,100)