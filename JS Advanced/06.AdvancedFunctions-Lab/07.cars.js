function solve(commands) {
    let objects = {};

    let processor = {
        create(name) {
            objects[name] = {};
        },
        createInherit(name, parentName) {
            objects[name] = {inherits: objects[parentName]};
        },
        set(name, key, value) {
            objects[name][key] = value;
        },
        print(name) {
           
        }
    };

    for (let cmd of commands) {
        let [action, name, argOne, argTwo] = cmd.split(' ');

        if (argOne == 'inherit') {
            processor['createInherit'](name, argTwo);
        } else {
            processor[action](name, argOne, argTwo);
        }
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);