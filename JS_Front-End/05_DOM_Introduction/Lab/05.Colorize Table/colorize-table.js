function colorize() {
    const liEl = document.querySelectorAll('table tbody tr');

    liEl.forEach((el,idx)=> {
        if (idx % 2 != 0){
            el.style.backgroundColor = 'Teal';
        }
    });
}