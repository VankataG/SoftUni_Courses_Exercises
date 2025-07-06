function nxnMatrix(n){
    for(let i =0; i < n; i++){
        let line = '';

        for(let f = 0;f < n; f++){
            line += n + ' ';
        }
        console.log(line.trim());
    }
}

nxnMatrix(3);