function loadCommits() {
    let username = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;

    let url = `https://api.github.com/repos/${username}/${repo}/commits`;

    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error(`${response.status} (Not Found)`);
            }
        })
        .then(commits => {
            let ulElement = document.getElementById('commits');
            ulElement.innerHTML = '';
            commits.forEach(e => {
                let commit = e.commit;
                let liElement = document.createElement('li');
                liElement.textContent = `${commit.author.name}: ${commit.message}`;
                ulElement.appendChild(liElement);
            });
        })
        .catch(e => {
            let ulElement = document.getElementById('commits');
            ulElement.innerHTML = '';
            let liElement = document.createElement('li');
            liElement.textContent = `Error: ${e.message}`;
            ulElement.appendChild(liElement);
        });
}