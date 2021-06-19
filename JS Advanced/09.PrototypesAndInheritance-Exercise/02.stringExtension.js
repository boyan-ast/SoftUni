(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }

        return this + '';
    };
    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }
        return this + '';
    };
    String.prototype.isEmpty = function () {
        if (this.length == 0) {
            return true;
        }
        return false;
    };
    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this + '';
        } else if (this.length > n && n >= 3) {
            let lastSpaceIndex = this.substr(0, n - 2).lastIndexOf(' ');
            
            if (lastSpaceIndex !== -1) {
                let result = this.slice(0, lastSpaceIndex) + '...';
                return result;
            } else {
                return this.slice(0, n - 3) + '...';
            }
        } else if (n < 4) {
            return '.'.repeat(n);
        }
    };

    String.format = function (string, ...params) {
        for (let i = 0; i < params.length; i++) {
            if (string.includes(`{${i}}`)) {
                string = string.replace(`{${i}}`, params[i]);
            }
        }

        return string;
    };
})();


let str = 'my string';
console.log(str);
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(10);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
    'dog');
console.log(str);
