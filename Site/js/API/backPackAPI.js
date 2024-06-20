const userId = localStorage.getItem('id');

async function fetchAllCartItems() {
    const response = await fetch(`http://192.168.45.250:3000/api/Cart/GetCarts?userId=${userId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (!response.ok) {
        throw new Error('Failed to fetch cart items');
    }
    const data = await response.json();
    return data;
}

async function fetchClotheData(clotheId) {
    const response = await fetch(`http://192.168.45.250:3000/api/CLothes/GetClothes?id=${clotheId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (!response.ok) {
        throw new Error('Failed to fetch clothe data');
    }
    const data = await response.json();
    
    // Сохраняем clotheId в localStorage
    localStorage.setItem('clotheId', clotheId);
    
    return data;
}

async function displayAllCartItems(items) {
    const container = document.querySelector('.container');
    container.innerHTML = '';

    for (const item of items) {
        if (item.cart_user === userId) {
            const clotheData = await fetchClotheData(item.cart_clotheid);
            const productData = clotheData.find(clothe => clothe.id === item.cart_clotheid);

            const productDiv = document.createElement('div');
            productDiv.className = 'product-info';

            productDiv.innerHTML = `
                <div class="discount-block">
                    <h2>-10%</h2>
                    <p>ВЫ ПОДТВЕРДИЛИ E-MAIL</p>
                </div>
                <div class="product-image">
                    <img src="../image/novinki/${productData.clothe_image}" alt="${productData.clothe_name}" onerror="this.onerror=null;this.src='../image/novinki/zagluha.png';">
                </div>
                <div class="product-details">
                    <h3>${productData.clothe_name}</h3>
                    <p>${productData.clothe_description}</p>
                </div>
                <div class="product-summary">
                    <h3>РАЗМЕР</h3>
                    <div class="size-options">
                       <p>${productData.clothe_size}</p>
                    </div>
                    <div class="price">
                       <p>${productData.clothe_price}</p>
                    </div>
                    <a href="../html/oformlenieTovaraPage.html" class="submit-button" data-product='${JSON.stringify(productData)}'>ОФОРМИТЬ</a>
                </div>
            `;

            container.appendChild(productDiv);
        }
    }
    addSubmitButtonClickListener();
}

function addSubmitButtonClickListener() {
    const buttons = document.querySelectorAll('.submit-button');
    buttons.forEach(button => {
        button.addEventListener('click', (event) => {
            const productData = event.currentTarget.getAttribute('data-product');
            localStorage.setItem('selectedProduct', productData);
        });
    });
}

fetchAllCartItems()
    .then(displayAllCartItems)
    .catch(error => console.error('Error loading cart items:', error));

