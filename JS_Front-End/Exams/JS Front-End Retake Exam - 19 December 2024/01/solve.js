function solve(input){
    const n = Number(input.shift());
    const astronautsInput = input.splice(0, n);

    const astronauts = astronautsInput.reduce((astronauts, astronaut) => {
        let [name, section, skills] = astronaut.split(' ');

        skills = skills.split(',');
        astronauts[name] = {section, skills};

        return astronauts;
    }, {});

    while(input.length > 0){
        const commandInput = input.shift();
        if(commandInput === 'End') continue;

        const commandData = commandInput.split(' / ');
        const command = commandData[0];
        const name = commandData[1];

        switch(command){
            case 'Perform':
                const section = commandData[2];
                const skill = commandData[3];
                if (astronauts[name].section === section && astronauts[name].skills.includes(skill)){
                    console.log(`${name} has successfully performed the skill: ${skill}!`);
                } else {
                    console.log(`${name} cannot perform the skill: ${skill}.`);
                }
            break;
            case 'Transfer':
                const newSection = commandData[2];

                astronauts[name].section = newSection;
                console.log(`${name} has been transferred to: ${newSection}`);

            break;
            case 'Learn Skill':
                const newSkill = commandData[2];

                if (astronauts[name].skills.includes(newSkill)){
                    console.log(`${name} already knows the skill: ${newSkill}.`);
                } else {
                    astronauts[name].skills.push(newSkill);
                    console.log(`${name} has learned a new skill: ${newSkill}.`);
                }
            break;
        }
    }
    Object.keys(astronauts).forEach(name => {
        console.log(`Astronaut: ${name}, Section: ${astronauts[name].section}, Skills: ${astronauts[name].skills.sort().join(', ')}`);
    });
}

solve([
  "2",
  "Alice command_module piloting,communications",
  "Bob engineering_bay repair,maintenance",
  "Perform / Alice / command_module / piloting",
  "Perform / Bob / command_module / repair",
  "Learn Skill / Alice / navigation",
  "Perform / Alice / command_module / navigation",
  "Transfer / Bob / command_module",
  "Perform / Bob / command_module / maintenance",
  "End"
]);