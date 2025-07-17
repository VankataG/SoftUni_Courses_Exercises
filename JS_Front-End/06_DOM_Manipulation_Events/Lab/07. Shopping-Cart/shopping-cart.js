document.addEventListener('DOMContentLoaded', solve);

function solve() {
   const addBtnEls = document.querySelectorAll('.add-product');
   const textareaEl = document.querySelector('textarea');
   const checkoutBtnEl = document.querySelector('.checkout');

   let products = new Set();
   let totalPrice = 0;

   addBtnEls.forEach(btnEl => {
      btnEl.addEventListener('click', addToCart);
   })

   checkoutBtnEl.addEventListener('click', showCheckout);

   function addToCart(e){
      const mainParentEl = e.target.closest('.product');

      const name = mainParentEl.querySelector('.product-details .product-title').textContent;
      const price = Number(mainParentEl.querySelector('.product-line-price').textContent);

      textareaEl.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
      products.add(name);
      totalPrice += price;
   }

   function showCheckout(){
      textareaEl.value += `You bought ${Array.from(products).join(', ')} for ${totalPrice.toFixed(2)}.`;
      addBtnEls.forEach(btn => btn.disabled = true);
      checkoutBtnEl.disabled = true;
   }
}
