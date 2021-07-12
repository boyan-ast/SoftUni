let homePageSection = document.getElementById('home-page');
let h1MoviesElement = document.querySelector('h1.text-center');
let movieSection = document.getElementById('movie');
let registerSection = document.getElementById('form-sign-up');
let loginSection = document.getElementById('form-login');

export function homePage() {
    homePageSection.classList.remove('hidden');
    h1MoviesElement.classList.remove('hidden');
    movieSection.classList.remove('hidden');
    
    if (!loginSection.classList.contains('hidden')) {
        loginSection.classList.add('hidden');
    }
    
    if (!registerSection.classList.contains('hidden')) {
        registerSection.classList.add('hidden');
    }
    
    let movieDetailsElement = document.querySelector('section.movie-details');

    if (!movieDetailsElement.classList.contains('hidden')) {
        movieDetailsElement.classList.add('hidden');
    }
}