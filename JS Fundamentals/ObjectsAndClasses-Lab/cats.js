function solve(catsList) {

    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        Meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (catInfo of catsList) {
        let [name, age] = catInfo.split(' ');

        let cat = new Cat(name, age);
        cat.Meow();
    }
}

solve(['Mellow 2', 'Tom 5']);