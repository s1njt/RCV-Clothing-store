document.addEventListener('DOMContentLoaded', () => {
    const addBackpackButton = document.querySelector('.addBackpack-button');
    addBackpackButton.addEventListener('click', addToCart);
});

async function addToCart() {
    const selectedClothe = JSON.parse(localStorage.getItem('selectedClothe'));
    const userId = localStorage.getItem('id');
    
    const data = {
        cart_user: userId,
        cart_clotheid: selectedClothe.id,
        cart_price: selectedClothe.clothe_price
    };

    try {
        const response = await fetch('http://192.168.45.250:3000/api/Cart/AddCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error('Ошибка добавления товара в корзину');
        }

        alert('Товар успешно добавлен в корзину');
    } catch (error) {
        console.error(error);
        alert('Произошла ошибка при добавлении товара в корзину');
    }
}