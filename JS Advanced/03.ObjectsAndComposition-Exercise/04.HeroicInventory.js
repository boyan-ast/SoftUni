function heroicInventory(input) {
    const heroes = [];

    for (let line of input) {
        let heroInfo = line.split(' / ');
        let name = heroInfo[0];
        let level = Number(heroInfo[1]);
        let items = [];

        if (heroInfo.length > 2) {
            items = heroInfo[2].split(', ');
        }

        heroes.push({ name: name, level: level, items: items });
    }

    const result = JSON.stringify(heroes);

    return result;
}

console.log(heroicInventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));