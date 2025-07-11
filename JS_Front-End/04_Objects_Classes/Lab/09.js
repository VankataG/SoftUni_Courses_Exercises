function songs(array){
    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];

    let count = array.shift();
    let printType = array.pop();

    for( let i = 0; i < count; i++){
        let songData = array[i].split('_');

        let newSong = new Song(songData[0], songData[1], songData[2]);

        songs.push(newSong);
    }

    

    if (printType === 'all'){
        songs.forEach(song => console.log(song.name));
    }
    else{
        songs
            .filter(song => song.typeList === printType)
            .forEach(song => console.log(song.name));
    }
}

songs(
    [
        3,
        'favourite_DownTown_3:14',
        'favourite_Kiss_4:16',
        'favourite_Smooth Criminal_4:01',
        'favourite'
    ]
);