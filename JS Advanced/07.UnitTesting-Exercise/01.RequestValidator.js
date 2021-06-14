function solve(input) {
    let method = input.method;
    let uri = input.uri;
    let version = input.version;
    let message = input.message;

    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if ((!input.hasOwnProperty('method')
        || (method != 'GET' && method != 'POST' && method != 'DELETE' && method != 'CONNECT'))) {
        throwError('Method');
    }

    let uriTest = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/.test(uri);

    if (!input.hasOwnProperty('uri')
        || (!uriTest && uri !== '*')) {
        throwError('URI');
    }

    if (!input.hasOwnProperty('version')
        || !versions.includes(version)) {
        throwError('Version');
    }

    if (!input.hasOwnProperty('message')
        || message.includes('>')
        || message.includes('<')
        || message.includes('&')
        || message.includes('\\')
        || message.includes('\"')
        || message.includes('\'')) {
        throwError('Message');
    }


    function throwError(arg) {
        throw new Error(`Invalid request header: Invalid ${arg}`);
    }

    return input;
}

console.log(solve({
    method: 'GET',
    uri: '*',
    version: 'HTTP/1.1',
    message: '<'
}
));
// console.log(solve({
//     method: 'OPTIONS',
//     uri: 'git.master',
//     version: 'HTTP/1.1',
//     message: '-recursive'
// }
// ));