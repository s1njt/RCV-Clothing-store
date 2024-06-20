// Находим элемент .cool
const coolDiv = document.querySelector('.cool');

// Создаем элемент счетчика и устанавливаем изначальное значение
const countElement = document.createElement('span');
countElement.textContent = '0';

// Создаем кнопки минуса и плюса
const minusButton = document.createElement('button');
minusButton.textContent = '-';
const plusButton = document.createElement('button');
plusButton.textContent = '+';

// Добавляем элементы в .cool в нужном порядке
coolDiv.appendChild(minusButton);
coolDiv.appendChild(countElement);
coolDiv.appendChild(plusButton);

// Добавляем обработчики событий для кнопок
minusButton.addEventListener('click', function() {
    let count = parseInt(countElement.textContent);
    if (count > 0) {
        countElement.textContent = count - 1;
    }
});

plusButton.addEventListener('click', function() {
    let count = parseInt(countElement.textContent);
    countElement.textContent = count + 1;
});