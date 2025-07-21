document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.getElementById('convert').addEventListener('click', (e) => {
        e.preventDefault();

        const inputUnitSelected = document.querySelector('#inputUnits').value;
        const outputUnitSelected = document.querySelector('#outputUnits').value;

        const input = Number(document.getElementById('inputDistance').value);
        const outputEl = document.getElementById('outputDistance');

        let meters = 0;

        switch (inputUnitSelected){
            case 'km':
                meters = input * 1000;
                break;
            case 'm':
                meters = input;
                break;
            case 'cm':
                meters = input * 0.01;
                break;
            case 'mm':
                meters = input * 0.001;
                break;
            case 'mi':
                meters = input * 1609.34;
                break;
            case 'yrd':
                meters = input * 0.9144;
                break;
            case 'ft':
                meters = input * 0.3048;
                break;
            case 'in':
                meters = input * 0.0254;
                break;
        }


        let convertedResult = 0;

        switch (outputUnitSelected){
            case 'km':
                convertedResult = meters / 1000;
                break;
            case 'm':
                convertedResult = meters;
                break;
            case 'cm':
                convertedResult = meters / 0.01;
                break;
            case 'mm':
                convertedResult = meters / 0.001;
                break;
            case 'mi':
                convertedResult = meters / 1609.34;
                break;
            case 'yrd':
                convertedResult = meters / 0.9144;
                break;
            case 'ft':
                convertedResult = meters / 0.3048;
                break;
            case 'in':
                convertedResult = meters / 0.0254;
                break;
        }

        outputEl.value = convertedResult;
    })
}