
function solve(input){
    const farmersCount = Number(input.shift());

    let farmers = [];
    for (let i = 0; i < farmersCount; i++){
        const farmerData = input.shift().split(' ');

        const name = farmerData[0];
        const area = farmerData[1];
        const tasks = farmerData[2].split(',');

        farmers.push( {name, area, tasks} );
    }

    while (input.length > 0){
        const command = input.shift();
        if(command === "End") break;

        const commandData = command.split(' / ');
        const action = commandData[0];
        const farmerName = commandData[1];

        if (action === "Execute"){
            const area = commandData[2];
            const task = commandData[3];

            const farmer = farmers.find(f => f.name === farmerName &&
                                            f.area === area &&
                                            f.tasks.includes(task)
            );

            if (!farmer){
                console.log(`${farmerName} cannot execute the task: ${task}.`);
            }
            else{
                console.log(`${farmerName} has executed the task: ${task}!`);
            }
        } else if (action === "Change Area"){
            const newArea = commandData[2];

            let farmer = farmers.find(f => f.name === farmerName);

            if(!farmer) continue;

            farmer.area = newArea;
            console.log(`${farmerName} has changed their work area to: ${newArea}`);
        } else if (action === "Learn Task"){
            const newTask = commandData[2];

            let farmer = farmers.find(f => f.name === farmerName);

            if(!farmer) continue;

            if(farmer.tasks.includes(newTask)){
                console.log(`${farmerName} already knows how to perform ${newTask}.`);
            } else {
                farmer.tasks.push(newTask);
                console.log(`${farmerName} has learned a new task: ${newTask}.`);
            }
        }
    }

    farmers.forEach(f => {
        console.log(`Farmer: ${f.name}, Area: ${f.area}, Tasks: ${f.tasks.sort().join(', ')}`);
    });
}

solve([
  "2",
  "John garden watering,weeding",
  "Mary barn feeding,cleaning",
  "Execute / John / garden / watering",
  "Execute / Mary / garden / feeding",
  "Learn Task / John / planting",
  "Execute / John / garden / planting",
  "Change Area / Mary / garden",
  "Execute / Mary / garden / cleaning",
  "End"
]);