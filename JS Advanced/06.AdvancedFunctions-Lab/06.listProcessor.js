function solve (commands) {
    let list = [];

    let processor = {
        add(input) {
            list.push(input);
        },
        remove(input) {
            list = list.filter(e => e!= input);
        },
        print() {
            console.log(list.join(','));
        }
    };

    for (let cmd of commands) {
        let [action, str] = cmd.split(' ');
        processor[action](str);
    }    
}


solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);