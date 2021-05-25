function editElement(ref, match, replacer) {
    const text = ref.textContent;
    const matcher = new RegExp(match, 'g');
    const output = text.replace(matcher, replacer);
    ref.textContent = output;
}