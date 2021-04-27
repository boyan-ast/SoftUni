function solve(listData) {

    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];
    let n = listData.shift();
    let filterType = listData.pop();

    for (let i = 0; i < n; i++) {
        let [typeList, name, time] = listData[i].split('_');
        let song = new Song(typeList, name, time);
        songs.push(song);
    }

    let selectedSongs = [];

    if (filterType != 'all') {
        selectedSongs = songs.filter(s => s.typeList == filterType);
    } else {
        selectedSongs = songs;
    }

    for (song of selectedSongs) {
        console.log(song.name);
    }
}

solve([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']    
);