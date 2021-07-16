export function setupHomepage(section, navigation) {
    section.querySelector('a').addEventListener('click', (e) => {
       e.preventDefault();
        navigation.goTo('dashboard');
    });

    return showHomepage;

    async function showHomepage() {
        return section;
    }
}