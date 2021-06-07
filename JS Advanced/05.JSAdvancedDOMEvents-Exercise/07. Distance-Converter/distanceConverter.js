function attachEventsListeners() {
    let inputUnitsElement = document.getElementById('inputUnits');
    let outputUnitsElement = document.getElementById('outputUnits');

    let inputElement = document.getElementById('inputDistance');
    let outputElement = document.getElementById('outputDistance');

    let convertButtonElement = document.getElementById('convert');

    convertButtonElement.addEventListener('click', convert);

    function convert(e) {
        let input = Number(inputElement.value);
        let inputUnits = inputUnitsElement.value;

        let inputInMeters = convertToMeters(input, inputUnits);
        
        let outputUnits = outputUnitsElement.value;

        let result = convertToRequiredUnits[outputUnits](inputInMeters);
        outputElement.value = result;
    }

    function convertToMeters(num, units) {
        let result = 0;
        switch (units) {
            case 'km':
                result = num * 1000;
                break;
            case 'm':
                result = num;
                break;
            case 'cm':
                result = num * 0.01;
                break;
            case 'mm':
                result = num * 0.001;
                break;
            case 'mi':
                result = num * 1609.34;
                break;
            case 'yrd':
                result = num * 0.9144;
                break;
            case 'ft':
                result = num * 0.3048;
                break;
            case 'in':
                result = num * 0.0254;
                break;
            default:
                break;
        }

        return result;
    }
    
    convertToRequiredUnits = {
        'km': (num) => num / 1000,
        'm': (num) => num,
        'cm': (num) => num * 100,
        'mm': (num) => num * 1000,
        'mi': (num) => num / 1609.34,
        'yrd': (num) => num / 0.9144,
        'ft': (num) => num / 0.3048,
        'in': (num) => num / 0.0254
    };
}