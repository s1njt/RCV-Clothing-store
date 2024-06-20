// Получаем поле ввода текста
var searchInput = document.querySelector(".search-input");

// Добавляем обработчик события для поля ввода текста
searchInput.addEventListener("keypress", function(event) {
    // Проверяем, была ли нажата клавиша Enter (код 13)
    if (event.key === "Enter") {
        // Запускаем функцию поиска
        performSearch();
    }
});

// Добавляем обработчик события для кнопки
document.getElementById("send-link").addEventListener("click", function(event) {
    event.preventDefault(); // Предотвращаем переход по ссылке
    // Запускаем функцию поиска
    performSearch();
});

// Получаем поле ввода текста
var searchInput = document.querySelector(".search-input");

// Добавляем обработчик события input для поля ввода текста
searchInput.addEventListener("input", function(event) {
    // Проверяем, пусто ли поле ввода
    if (searchInput.value.trim() === "") {
        // Если поле ввода пустое, очищаем результаты поиска
        clearSearchResults();
    }
});

// Функция для очистки результатов поиска
function clearSearchResults() {
    // Очищаем содержимое контейнера результатов поиска
    document.querySelector(".result #search-result").innerHTML = "";
    // Сбрасываем счетчик количества результатов
    document.querySelector(".search-results-col label").textContent = "КОЛИЧЕСТВО РЕЗУЛЬТАТОВ: 0";
}

// Функция для выполнения поиска
function performSearch() {
    var searchText = searchInput.value.trim().toLowerCase(); // Получаем введенный текст, удаляем пробелы в начале и в конце, и приводим к нижнему регистру
    var allText = document.body.textContent.toLowerCase(); // Получаем весь текст на странице и приводим к нижнему регистру через textContent
    var count = 0;
    var resultContainer = document.querySelector(".result #search-result"); // Контейнер для результатов поиска
    resultContainer.innerHTML = ""; // Очищаем предыдущие результаты поиска
    
    if (searchText === "") {
        // Если поисковый запрос пустой, просто очищаем результаты и выходим из функции
        clearSearchResults();
        return;
    }

    var regex = new RegExp(searchText.replace(/[.*+?^${}()|[\]\\]/g, '\\$&'), "gi"); // Создаем регулярное выражение для поиска
    
    // Ищем все совпадения и добавляем их в контейнер результатов
    while ((match = regex.exec(allText)) !== null) {
        var resultText = match[0]; // Текст результата (найденного слова)
        var resultHTML = "<p><strong class='search-result-text'>" + resultText.toUpperCase() + "</strong></p>"; // Добавляем найденное совпадение в контейнер
        resultContainer.innerHTML += resultHTML;
        count++; // Увеличиваем счетчик найденных результатов
    }
    
    // Добавляем обработчик события клика для каждого найденного элемента
    var resultElements = document.querySelectorAll(".search-result-text");
    resultElements.forEach(function(element) {
        element.addEventListener("click", function() {
            // Прокручиваем к этому элементу
            var parent = element.parentElement; // Получаем родительский элемент, чтобы убедиться, что прокрутка сработает точно
            parent.scrollIntoView({ behavior: 'smooth', block: 'start' });
        });
    });
    
    // Выводим количество результатов в блок .search-results-col
    document.querySelector(".search-results-col label").textContent = "КОЛИЧЕСТВО РЕЗУЛЬТАТОВ: " + count;
}