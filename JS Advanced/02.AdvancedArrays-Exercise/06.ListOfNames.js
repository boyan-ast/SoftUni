function listNames(names) {
    const list = names.sort(sortFunc).forEach((n, i) => {console.log(`${i+1}.${n}`)});
    
    function sortFunc(a, b) {
        return a.localeCompare(b);
    }
}

listNames(["John", "Bob", "Christina", "Ema"]);