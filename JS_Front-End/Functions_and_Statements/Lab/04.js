function orderPrice(product, quantity)
{
    let price;
    switch(product)
    {
        case 'coffee': 
        price = 1.50;
        break;
        case 'water': 
        price = 1; 
        break;
        case 'coke': 
        price = 1.40; 
        break;
        case 'snacks': 
        price = 2; 
        break;
    }
    let total = quantity * price;
    console.log(total.toFixed(2));
}