document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const daysFormEl = document.getElementById('days');
    const hoursFormEl = document.getElementById('hours');
    const minutesFormEl = document.getElementById('minutes');
    const secondsFormEl = document.getElementById('seconds');

    daysFormEl.addEventListener('submit', (e) => {
        e.preventDefault();
        handleConvert('days-input');
    });
    hoursFormEl.addEventListener('submit', (e) => {
        e.preventDefault();
        handleConvert('hours-input');
    });
    minutesFormEl.addEventListener('submit', (e) => {
        e.preventDefault();
        handleConvert('minutes-input');
    });
    secondsFormEl.addEventListener('submit', (e) => {
        e.preventDefault();
        handleConvert('seconds-input');
    });

    function handleConvert(unitId){
        
        const inputValue = Number(document.getElementById(unitId).value);

        if (!inputValue) return;

        let days, hours, minutes, seconds;

        switch (unitId) {
            case 'days-input':
                days = inputValue;
                hours = days * 24;
                minutes = hours * 60;
                seconds = minutes * 60
                break;
            case 'hours-input':
                hours = inputValue;
                days = hours / 24;
                minutes = hours * 60;
                seconds = minutes * 60
                break;
            case 'minutes-input':
                minutes = inputValue;
                hours = minutes / 60;
                seconds = minutes * 60
                days = hours / 24;
                break;
            case 'seconds-input':
                seconds = inputValue;
                minutes = seconds / 60;
                hours = minutes / 60;
                days = hours / 24;
                break;
        }

        document.getElementById('days-input').value = days.toFixed(2);
        document.getElementById('hours-input').value = hours.toFixed(2);
        document.getElementById('minutes-input').value = minutes.toFixed(2);
        document.getElementById('seconds-input').value = seconds.toFixed(2);
        
    }   
}