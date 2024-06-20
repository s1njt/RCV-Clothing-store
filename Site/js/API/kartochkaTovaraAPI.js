document.addEventListener('DOMContentLoaded', () => {
    loadProductInfo();
});

function loadProductInfo() {
    // Получаем информацию о товаре
    const selectedClothe = JSON.parse(localStorage.getItem('selectedClothe'));
    const userId = localStorage.getItem('id'); // Получаем ID пользователя из localStorage

    // Сохраняем выбранный товар в localStorage
    localStorage.setItem('selectedProduct', JSON.stringify(selectedClothe));

    // Заполняем product-info информацией о товаре
    const productInfo = document.querySelector('.product-info');
    const h1Element = productInfo.querySelector('h1');
    const pDescription = productInfo.querySelector('.description');
    const pTextile = productInfo.querySelector('.textile');
    const pColor = productInfo.querySelector('.color');
    const priceElement = document.querySelector('.price');
    const sizeOptions = document.querySelector('.size-options');

    h1Element.innerHTML = `${selectedClothe.clothe_name}`;
    pDescription.textContent = selectedClothe.clothe_description;
    pTextile.nextElementSibling.textContent = selectedClothe.clothe_textile; // Найти следующий элемент после pTextile
    pColor.nextElementSibling.textContent = selectedClothe.clothe_color; // Найти следующий элемент после pColor
    priceElement.textContent = `₽${selectedClothe.clothe_price.toFixed(2)}`;

    // Добавляем фотографии товара
    const imageContainer1 = document.querySelector('.block-left:nth-of-type(1) .image-container');
    const imageContainer2 = document.querySelector('.block-left:nth-of-type(2) .image-container');
    const imageContainer3 = document.querySelector('.block-left:nth-of-type(3) .image-container');

    const img1 = document.createElement('img');
    img1.src = `..//image/kartochkaTovara/${selectedClothe.clothe_image}`;
    img1.alt = selectedClothe.clothe_name;
    imageContainer1.appendChild(img1);

    const img2 = document.createElement('img');
    img2.src = `..//image/kartochkaTovara/${selectedClothe.clothe_image}`;
    img2.alt = selectedClothe.clothe_name;
    imageContainer2.appendChild(img2);

    const img3 = document.createElement('img');
    img3.src = `..//image/kartochkaTovara/${selectedClothe.clothe_image}`;
    img3.alt = selectedClothe.clothe_name;
    imageContainer3.appendChild(img3);

    // Добавляем размеры товара
    const sizes = selectedClothe.clothe_size.split(',').map(size => size.trim());
    sizeOptions.innerHTML = sizes.map(size => `<p>${size}</p>`).join('');
}