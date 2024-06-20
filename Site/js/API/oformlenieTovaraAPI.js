document.addEventListener('DOMContentLoaded', () => {
    const productData = JSON.parse(localStorage.getItem('selectedProduct'));

    if (productData) {
        const tovarPhoto = document.getElementById('tovar-photo');
        tovarPhoto.src = `../image/novinki/${productData.clothe_image}`;
        tovarPhoto.alt = productData.clothe_name;
        tovarPhoto.onerror = function() {
            this.onerror = null;
            this.src = '../image/novinki/zagluha.png';
        };

        document.getElementById('product-name').textContent = productData.clothe_name;
        document.getElementById('product-size').textContent = productData.clothe_size;
        document.getElementById('product-price').textContent = `₽${productData.clothe_price.toFixed(2)}`;
    } else {
        console.error('No product data found in localStorage');
    }
});

document.getElementById('pay-button').addEventListener('click', async () => {
    const userId = localStorage.getItem('id');
    const clotheId = localStorage.getItem('clotheId');
    const address = document.getElementById('address').value;
    const postalCode = document.getElementById('postal-code').value;
    const fio = document.getElementById('fio').value;
    const cardNumber = document.getElementById('card-number').value;
    const expiryDate = document.getElementById('expiry-date').value;
    const cvv = document.getElementById('cvv').value;

    if (!userId || !clotheId || !cardNumber || !expiryDate || !cvv || !address || !postalCode || !fio) {
        alert('Пожалуйста, заполните все поля.');
        return;
    }

    // Форматируем текущую дату в формат, соответствующий datetime2(7)
    const currentDate = new Date().toISOString().slice(0, 23).replace('T', ' ');

    const ticketData = {
        ticket_acceptUserId: userId,
        ticket_productsId: clotheId,
        ticket_contactNumber: '', // Замените на фактический номер контакта
        ticket_deliveryAdress: address,
        ticket_deliveryStatus: '', // Замените на фактический статус доставки
        ticket_sum: 0, // Замените на фактическую сумму
        ticket_date: currentDate // Добавляем текущую дату в нужном формате
    };

    try {
        const response = await fetch('http://192.168.45.250:3000/api/Tickets/AddTicket', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(ticketData)
        });

        if (!response.ok) {
            throw new Error('Failed to add ticket');
        }

        const result = await response.json();
        console.log('Ticket added successfully:', result);
        alert('Заказ успешно добавлен');
    } catch (error) {
        console.error('Error adding ticket:', error);
        alert('Ошибка при добавлении заказа');
    }
});