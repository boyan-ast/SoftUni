function extensibleObject() {
    const instance = {};
    const prototype = {};
    Object.setPrototypeOf(instance, prototype);

    instance.extend = function (template) {
        Object.entries(template).forEach(([key, value]) => {
            if (typeof value === 'function') {
                prototype[key] = value;
            } else {
                instance[key] = value;
            }
        });
    }

    return instance;
}


const myObj = extensibleObject();

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
myObj.extend(template);
console.log(myObj);
