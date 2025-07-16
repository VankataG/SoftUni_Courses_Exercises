function printValidMoviesJson(movieArr){

    let allMovies = [];

    for( let input of movieArr){
        if (input.includes('addMovie')){
            let [ _ , movieName] = input.split('addMovie ');
            let movieObj = { name: movieName};
            allMovies.push(movieObj);
        } else if (input.includes('directedBy')){
            let [movieName, movieDirector] = input.split(' directedBy ');
            let existingMovie = allMovies.find(movie => movie.name === movieName);

            if (existingMovie){
                existingMovie.director = movieDirector;
            }
        } else if (input.includes('onDate')){
            let [movieName, movieDate] = input.split(' onDate ');
            let existingMovie = allMovies.find(movie => movie.name === movieName);

            if (existingMovie){
                existingMovie.date = movieDate;
            }
        }
    }

    let filteredMovies = allMovies.filter(m => m.director && m.date);
    filteredMovies.forEach(movie => console.log(JSON.stringify(movie)))
}

printValidMoviesJson(
    [
        'addMovie Fast and Furious',
        'addMovie Godfather',
        'Inception directedBy Christopher Nolan',
        'Godfather directedBy Francis Ford Coppola',
        'Godfather onDate 29.07.2018',
        'Fast and Furious onDate 30.07.2018',
        'Batman onDate 01.08.2018',
        'Fast and Furious directedBy Rob Cohen'
    ]
)