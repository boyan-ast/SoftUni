function createSortedList() {
    class List {
        constructor() {
            this.elements = [];
            this.size = 0;
        }

        add(element) { 
            this.elements.push(element);
            this.size++;
            this.elements.sort((a, b) => a - b);
        }

        remove(index) {
            if (index >= 0 && index < this.elements.length) {
                this.elements.splice(index, 1);
                this.size--;
            }

            this.elements.sort((a, b) => a - b);
        }

        get(index) {
            if (index >= 0 && index < this.elements.length) {
                return this.elements[index];
            }
        }
    }

    return new List();
}

let list = createSortedList();
console.log(list.add(5));
console.log(list.add(6));
console.log(list.add(7));

console.log(list.add(3));
console.log(list.get(1));
console.log(list.remove(10));
console.log(list.get(1));
