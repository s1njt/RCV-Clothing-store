const userId = localStorage.getItem('id');
console.log('User ID:', userId);

async function fetchAllTickets() {
    const response = await fetch(`http://192.168.45.250:3000/api/Tickets/GetTickets?ticket_acceptUserId=${userId}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (!response.ok) {
        throw new Error('Failed to fetch tickets');
    }
    const data = await response.json();

    // Выводим нужную строку в консоль
    data.forEach(ticket => {
        console.log('"ticket_acceptUserId": "', ticket.ticket_acceptUserId, '"');
    });

    return data;
}

// Function to display all tickets in the UI
async function displayAllTickets(tickets) {
    const orderDetailsTable = document.querySelector('.order-details tbody');
    orderDetailsTable.innerHTML = '';

    tickets.forEach(ticket => {
        if (ticket.ticket_acceptUserId === userId) {
            const row = document.createElement('tr');

            // Column: ФОТО НАЗВАНИЕ
            const imageCell = document.createElement('td');
            const image = document.createElement('img');
            image.src = `../image/novinki/${ticket.ticket_productsId}.png`; // Assuming ticket_productsId is the image name
            image.alt = `Товар ${ticket.ticket_productsId}`;
            image.onerror = function() {
                this.onerror = null;
                this.src = '../image/novinki/zagluha.png'; // Placeholder image on error
            };
            imageCell.appendChild(image);
            row.appendChild(imageCell);

            // Column: АРТИКУЛЬ
            const articulCell = document.createElement('td');
            articulCell.textContent = ticket.ticket_productsId; // Using ticket_productsId as the article number
            row.appendChild(articulCell);

            // Column: СУММА
            const sumCell = document.createElement('td');
            sumCell.textContent = `₽${ticket.ticket_sum.toFixed(2)}`;
            row.appendChild(sumCell);

            // Column: ДАТА
            const dateCell = document.createElement('td');
            dateCell.textContent = new Date(ticket.ticket_createDate).toLocaleDateString();
            row.appendChild(dateCell);

            // Column: СТАТУС
            const statusCell = document.createElement('td');
            statusCell.textContent = ticket.ticket_deliveryStatus; // Assuming ticket_deliveryStatus is the status
            row.appendChild(statusCell);

            // Column: АДРЕС ДОСТАВКИ
            const addressCell = document.createElement('td');
            addressCell.textContent = ticket.ticket_deliveryAdress;
            row.appendChild(addressCell);

            // Column: ОТОЗВАТЬ ЗАКАЗ
            const cancelCell = document.createElement('td');
            const cancelButton = document.createElement('button');
            cancelButton.textContent = 'ОТОЗВАТЬ';
            cancelButton.classList.add('cancel-button');
            cancelButton.addEventListener('click', () => {
                // Add logic to cancel the order here, e.g., send a request to cancel the order
                alert('ТОВАР УСПЕШНО ОТОЗВАН');
                // Optionally, you can remove the row from UI after cancellation
                row.remove();
            });
            cancelCell.appendChild(cancelButton);
            row.appendChild(cancelCell);

            orderDetailsTable.appendChild(row);
        }
    });

    addSubmitButtonClickListener(); // Ensure submit button click listeners are added after rendering
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

// Fetch tickets and display them
async function fetchAndDisplayTickets() {
    try {
        const tickets = await fetchAllTickets();
        await displayAllTickets(tickets);
    } catch (error) {
        console.error('Error loading tickets:', error);
    }
}

// Call the function to fetch and display tickets
fetchAndDisplayTickets();