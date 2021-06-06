function solve() {
   let buttonElements = document.querySelectorAll('button.add-product');
   let textAreaElement = document.querySelector('textArea');
   let products = {};
   let totalSum = 0;

   for (let el of buttonElements) {
      el.addEventListener('click', function (e) {
         let productElement = e.currentTarget.parentNode.parentNode;
         let productName = productElement.querySelector('.product-title').textContent;
         let productPrice = Number(productElement.querySelector('.product-line-price').textContent);
         totalSum += productPrice;

         if (products[productName] == undefined) {
            products[productName] = 0;
         }
         products[productName]++;
         
         textAreaElement.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
      });
   }

   let checkoutButtonElement = document.querySelector('button.checkout');

   checkoutButtonElement.addEventListener('click', function (e) {
      textAreaElement.value += `You bought ${Object.keys(products).join(', ')} for ${totalSum.toFixed(2)}.`
      let allButtonElements = Array.from(document.getElementsByTagName('button'));
      allButtonElements.forEach(el => el.setAttribute('disabled', 'true'));
   });
}