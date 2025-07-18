document.addEventListener('DOMContentLoaded', solve);

function solve() {
    
    document.querySelector('form#encode').addEventListener('submit', (e) => {
        e.preventDefault();

        const decodeFormEl = document.querySelector('form#decode');
        const textareaEl = e.target.querySelector('textarea');
        const message = textareaEl.value;
        const encodedMessageTextareaEl = decodeFormEl.querySelector('textarea');
        
        const charsArr = message.split('');
        let encodedMessage = '';

        charsArr.forEach(char => {
            const encodedChar = String.fromCharCode(char.charCodeAt() + 1);
            
            encodedMessage += encodedChar;
            
        });
        
        encodedMessageTextareaEl.value = encodedMessage;
        textareaEl.value = '';
        

        decodeFormEl.addEventListener('submit', (e) => {
            e.preventDefault();

            encodedMessageTextareaEl.value = message;
            
        })
    })
 
}