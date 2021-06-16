class Stringer {
    constructor(input, length){
        this.innerString = input;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(lenght) {
        this.innerLength -= lenght;

        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let result = '';
        result += this.innerString.substring(0, this.innerLength);

        if (this.innerLength < this.innerString.length) {
            result += '...';
        }

        return result;

    }
}



let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
