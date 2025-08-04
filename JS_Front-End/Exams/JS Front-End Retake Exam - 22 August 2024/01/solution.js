
function solve(input){
    const n = input.shift();

    let chemicals = [];
    for (let i = 0; i < n; i++){
        const chemicalData = input.shift().split(' # ');
        const name = chemicalData[0];
        const quantity = Number(chemicalData[1]);

        let chemical = {name, quantity, formula: null};
        chemicals.push(chemical);
    }

    while(input.length > 0){
        const command = input.shift();

        if (command === 'End') break;

        const commandData = command.split(' # ');
        const action = commandData[0];
        const chemicalName = commandData[1];
        const chemical = chemicals.find(ch => ch.name === chemicalName);
        if (action === 'Mix'){
            const chemical2Name = commandData[2];
            const amount = commandData[3];
            const chemical2 = chemicals.find(ch => ch.name === chemical2Name);


            if (chemical.quantity >= amount && chemical2.quantity >= amount){
                console.log(`${chemicalName} and ${chemical2Name} have been mixed. ${amount} units of each were used.`)
                chemical.quantity -= amount;
                chemical2.quantity -= amount;
            } else {
              console.log(`Insufficient quantity of ${chemicalName}/${chemical2Name} to mix.`)
            }

        } else if (action === 'Replenish'){
            if (!chemical){
                console.log(`The Chemical ${chemicalName} is not available in the lab.`);
            } else {
                const amount = Number(commandData[2]);
                chemical.quantity += amount;

                if (chemical.quantity > 500){
                    const addedAmount = amount - (chemical.quantity - 500);
                    chemical.quantity = 500;
                    console.log(`${chemicalName} quantity increased by ${addedAmount} units, reaching maximum capacity of 500 units!`)
                } else {
                    console.log(`${chemicalName} quantity increased by ${amount} units!`)
                }
            }
        } else if (action === 'Add Formula'){
            const formula = commandData[2];
            if (!chemical){
                console.log(`The Chemical ${chemicalName} is not available in the lab.`);
            } else {
                chemical.formula = formula;
                console.log(`${chemicalName} has been assigned the formula ${formula}.`);
            }
        }
    }

    chemicals.forEach(ch => {
        if (ch.formula != null){
            console.log(`Chemical: ${ch.name}, Quantity: ${ch.quantity}, Formula: ${ch.formula}`);
        } else {
            console.log(`Chemical: ${ch.name}, Quantity: ${ch.quantity}`);
        }
    })
}

solve([ 
    '4',
  'Water # 200',
  'Salt # 100',
  'Acid # 50',
  'Base # 80',
  'Mix # Water # Salt # 50',
  'Replenish # Salt # 150',
  'Add Formula # Acid # H2SO4',
  'End'
])