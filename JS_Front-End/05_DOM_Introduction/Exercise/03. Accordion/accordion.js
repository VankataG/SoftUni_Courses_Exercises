function toggle() {
    let button = document.querySelector('.button');

    
    let accordionDiv = document.getElementById('extra');
    if(button.textContent == 'More'){
        button.textContent = 'Less';
        accordionDiv.style.display = 'block';
    }
    else if(button.textContent == 'Less'){
        button.textContent = 'More';
        accordionDiv.style.display = 'none';
    }

}