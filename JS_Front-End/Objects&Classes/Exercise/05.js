function heroesRegister(array){
    let heroes = [];

    for( let element of array ){
        let heroData = element.split(' / ');

        let heroName = heroData[0];
        let heroLevel = Number(heroData[1]);
        let heroItems = heroData[2].split(', ');

        let newHero = {
            name: heroName,
            level: heroLevel,
            items: heroItems,
        }

        heroes.push(newHero);
    }

    heroes
    .sort((a,b) => a.level - b.level)
    .forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);
    })
}

heroesRegister(
    [
        'Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);