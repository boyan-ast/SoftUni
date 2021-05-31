function solve() {
  const input = document.querySelector('#input').value;

  const textArr = input.split('.').filter(x => x.length > 0);

  const groups = Math.floor(textArr.length / 3);

  //console.log(groups);

  const groupedText = [];

  for (let i = 0; i < groups; i++) {
    groupedText[i] = [];
    for (let j = 0; j < 3; j++) {
      groupedText[i].push(textArr.shift());
    }
  }

  if (textArr.length) {
    groupedText.push(textArr);
  }

  //console.log(groupedText);

  let result = '';

  for (let i = 0; i < groupedText.length; i++) {
    result += `<p>${groupedText[i].join('.')}.</p>\n`;

    document.querySelector('#output').innerHTML = result;
  }
}
