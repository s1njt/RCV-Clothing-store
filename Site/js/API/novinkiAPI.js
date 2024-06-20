// Функция для выполнения запроса к API
function fetchData() {
  fetch('http://192.168.45.250:3000/api/CLothes/GetClothes')
    .then(response => response.json())
    .then(data => {
      // Обработка полученных данных
      const clothesContainer = document.getElementById('clothes-container');
      data.forEach(clothe => {
        const clotheDiv = document.createElement('div');
        clotheDiv.classList.add('block-wrapper');
        clotheDiv.innerHTML = `
          <div class="block-left">
            <h1>${clothe.clothe_name}</h1>
            <h2>₽${clothe.clothe_price.toFixed(2)}</h2>
            <div class="image-container">
              <img src="../image/novinki/${clothe.clothe_image}" alt="${clothe.clothe_name}" onerror="this.onerror=null;this.src='../image/novinki/zagluha.png';">
            </div>
            <div class="dimensions">
              <h3>РАЗМЕРЫ</h3>
              <div class="size-options">
                ${parseSizes(clothe.clothe_size)}
              </div>
            </div>
          </div>
        `;
        clothesContainer.appendChild(clotheDiv);
      });
    })
    .catch(error => console.error('Ошибка получения данных:', error));
}

// Функция для парсинга информации о размерах и возврата HTML-разметки
function parseSizes(sizesString) {
  const sizes = sizesString.split(',').map(size => size.trim());
  return sizes.map(size => `<p>${size}</p>`).join('');
}

// Вызов функции для получения данных
fetchData();