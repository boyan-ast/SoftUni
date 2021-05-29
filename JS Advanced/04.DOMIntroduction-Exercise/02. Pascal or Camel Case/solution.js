function solve() {
  const text = document.getElementById('text').value.toLowerCase();
  const convention = document.getElementById('naming-convention').value;

  const textArray = text.split(' ');
  
  let output = textArray.map(w => {
    let newWord = w.charAt(0).toUpperCase() + w.slice(1);
    return newWord;
  }).join('');  

  if (convention == 'Camel Case') {
    output = output.charAt(0).toLowerCase() + output.slice(1);
  } else if (convention != 'Pascal Case') {
    output = 'Error!';
  }

  document.querySelector('#result').textContent = output;
}