function storeRevision(stockArr, orderedArr){
    let totalProducts = [];

    for (let i = 0; i < stockArr.length; i+=2){
        let name = stockArr[i];
        let quantity = Number(stockArr[i + 1]);

        let product = { name, quantity };

        totalProducts.push(product)
    }

    for (let i = 0; i < orderedArr.length; i+=2){
        let name = orderedArr[i];
        let quantity = Number(orderedArr[i + 1]);

        let existingProduct = totalProducts.find(product => product.name === name)
        
        if (existingProduct === undefined){

            let product = { name, quantity };
            totalProducts.push(product)
        }
        else{
            existingProduct.quantity += quantity;
        }
        
    }

    totalProducts.forEach(product => console.log(`${product.name} -> ${product.quantity}`));
    
}

storeRevision(
    [
        'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],  
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
)