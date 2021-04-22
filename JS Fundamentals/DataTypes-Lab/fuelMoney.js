function fuelMoney(distance, passengers, pricePerLiter) {

    let totalFuel = distance / 100 * 7;
    totalFuel += passengers * 0.1;
    let money = totalFuel * pricePerLiter;

    console.log(`Needed money for that trip is ${money}lv.`);
}

fuelMoney(90, 14, 2.88);