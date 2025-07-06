function printLoadingBar(num){
    let loadingArr = [];
    loadingArr.push('[');
    count = 0;
    countMax = num / 10;
    for(let i = 0; i < 10; i++)
    {
        if(count < countMax){
            count++;
            loadingArr.push('%');
        }
        else{
            loadingArr.push('.');
        }
    }
    loadingArr.push(']');

    if (num != 100){
        console.log(num + '% ' + loadingArr.join(''));
        console.log('Still loading...')
    }
    else{
        console.log('100% Complete!');
        console.log(loadingArr.join(''));
    }
}

printLoadingBar(100);