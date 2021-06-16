class List {
    constructor (){
        this.elements = [];
        this.size = 0;
    }

    add(element) {
        this.elements.push(element);
        this.size++;
        this.elements.sort((a, b) => a - b);
        return this.elements;
    }

    remove(index) {
        if (index < 0 || index >= this.elements.length) {
            throw new Error('Invalid index');
        }
        this.size--;
        this.elements.splice(index, 1);
        return this.elements;
    }

    get(index) {
        if (index < 0 || index >= this.elements.length) {
            throw new Error('Invalid index');
        }

        return this.elements[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size)
