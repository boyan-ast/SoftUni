function attachGradientEvents() {
    let gradientBoxElement = document.getElementById('gradient-box');
    let resultElement = document.getElementById('result');

    gradientBoxElement.addEventListener('mousemove', calculatePercentage);
    gradientBoxElement.addEventListener('mouseout', (e) => {
        resultElement.textContent = '';
    });

    function calculatePercentage (e) {
        let clickX = e.offsetX;
        let totalWidth = e.target.clientWidth;

        let resultPercentage = Math.trunc(clickX / totalWidth * 100);

        resultElement.textContent = `${resultPercentage}%`;
    }
}