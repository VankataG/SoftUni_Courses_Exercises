function largestNumber(a, b, c){
    let largest;
    if (a > b) largest = a;
    else largest = b;

    if (c > largest) largest = c;

    console.log(`The largest number is ${largest}.`)
}

largestNumber(1,-123,-22.5);