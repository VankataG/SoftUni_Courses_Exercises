function employees(array){

    let employees = [];

    for (let employee of array){
        employees.push({ name: employee, number: employee.length})
    }

    for (let employee of employees){
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.number}`)
    }
}

employees(
    [
        'Silas Butler',
        'Adnaan Buckley',
        'Juan Peterson',
        'Brendan Villarreal'
    ]
)