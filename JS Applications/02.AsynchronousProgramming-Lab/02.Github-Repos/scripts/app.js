function loadRepos() {
	let inputElement = document.getElementById('username');
	let username = inputElement.value;

	let url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(response => {
			if (response.ok) {
				return response.json();
			}
			else {
				throw Error('Username doesn\'t exist!')
			}
		})
		.then(data => {
			let ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';

			data.forEach(r => {
				let liElement = document.createElement('li');
				let aElement = document.createElement('a');
				aElement.setAttribute('href', r.html_url);
				aElement.textContent = r.full_name;
				liElement.appendChild(aElement);
				ulElement.appendChild(liElement);
			});
		})
		.catch(e => {
			let ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';
			let liElement = document.createElement('li');
			liElement.textContent = e;
			ulElement.appendChild(liElement);
		});
}