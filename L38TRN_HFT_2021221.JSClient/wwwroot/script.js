let artists = [];
let connection = null;
let artistIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:3445/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });
    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();

    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:3445/artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            console.log(y);
            display();
    });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.artistName + "</td><td>" +
        `<button onclick="remove(${t.id})">Delete</button>` +
        `<button onclick="showupdate(${t.id})">Update</button>` +
            "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('artistnametoupdate').value = artists.find(t => t['id'] == id)['artistName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    artistIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('artistnametoupdate').value;

    fetch('http://localhost:3445/artist', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                artistName: name, id: artistIdToUpdate
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:3445/artist/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function create() {
    let name = document.getElementById('artistname').value;

    fetch('http://localhost:3445/artist', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                artistName: name
            })})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}