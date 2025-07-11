function meowingCats(array){

    //Create class
    class Cat{
        constructor(name,age){
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`)
        }
    }
    
    //Solution
    for( let element of array){
        let catData = element.split(' ');
        let newCat = new Cat(catData[0], catData[1]);

        newCat.meow();
    }
}

meowingCats(
    ['Candy 1', 'Poppy 3', 'Nyx 2']
)