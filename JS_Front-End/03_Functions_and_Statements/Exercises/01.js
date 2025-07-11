function printSmallest(a,b,c){
    let smallest = a;
    if (smallest > b) smallest = b;
    if(smallest > c) smallest = c;
    console.log(smallest);
    
}

printSmallest(2,2,2);