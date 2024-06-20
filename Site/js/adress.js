// Создаем объект с адресами для каждого города
const addresses = {
    "Нижний Новгород": [
        "ул. Большая Покровская, д. 13",
        "пр. Гагарина, д. 92",
        "ул. Варварская, д. 19"
    ],
    "Москва": [
        "Тверская ул., д. 6",
        "Пресненская наб., д. 10",
        "Новинский бул., д. 12"
    ],
    "Санкт-Петербург": [
        "Невский проспект, д. 30",
        "Большая Конюшенная ул., д. 19",
        "Малая Конюшенная ул., д. 10"
    ]
};

// Находим блок, куда будем вставлять адреса
const addressBlock = document.querySelector('.address-block');

// Находим все ссылки городов
const gorodLinks = document.querySelectorAll('.gorod');

// Назначаем обработчик события на каждую ссылку города
gorodLinks.forEach(link => {
    link.addEventListener('click', function() {
        // Получаем город из атрибута data-city
        const city = this.getAttribute('data-city');
        
        // Получаем соответствующий массив адресов из объекта addresses
        const addressesForCity = addresses[city];
        
        // Генерируем HTML для всех адресов в массиве
        const addressHTML = addressesForCity.map(address => `<p>${address}</p>`).join('');
        
        // Вставляем сгенерированный HTML в блок address-block
        addressBlock.innerHTML = addressHTML;
    });
});