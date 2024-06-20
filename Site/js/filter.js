// ПОЯВЛЕНИЕ/ЗАКРЫВАНИЕ ФИЛЬТРА 
document.getElementById('filter-link').addEventListener('click', function(event) {
    event.preventDefault(); // Предотвращаем стандартное действие ссылки
    var filterForm = document.getElementById('filter-form');
    filterForm.classList.toggle('active'); // Переключаем класс для показа/скрытия формы
    // Добавляем обработчик клика на всю страницу
    document.addEventListener('click', function(event) {
    var filterForm = document.getElementById('filter-form');
    var filterLink = document.getElementById('filter-link');
    
    // Проверяем, был ли клик внутри формы или по ссылке "ФИЛЬТР"
    if (!filterForm.contains(event.target) && event.target !== filterLink) {
        filterForm.classList.remove('active'); // Скрываем форму
    }
});
});



// ЦВЕТ ПРИ КЛИКЕ
// Получаем все ячейки таблицы
const cells = document.querySelectorAll('.color-table td');

// Добавляем обработчик события для каждой ячейки
cells.forEach(cell => {
    cell.addEventListener('mouseover', function() {
        this.style.backgroundColor = "black"; // Фон ячейки становится черным
        this.style.color = "white"; // Цвет текста становится белым
    });

    cell.addEventListener('mouseleave', function() {
        if (!this.parentNode.classList.contains('clicked')) {
            this.style.backgroundColor = ""; // Убираем фон ячейки
            this.style.color = ""; // Восстанавливаем цвет текста
        }
    });

    cell.addEventListener('click', function() {
        // Удаляем класс 'clicked' у всех ячеек
        cells.forEach(c => c.classList.remove('clicked'));
        // Добавляем класс 'clicked' к текущей ячейке
        this.classList.add('clicked');
    });
});

// РАЗМЕР ПРИ КЛИКЕ