function listProducts(products) {
    let list = products.sort().map((p, i) => `${i+1}.${p}`);
    console.log(list.join('\r\n'));
}

listProducts(["Potatoes", "Tomatoes", "Onions", "Apples"]);