// Получаем все ссылки чата
var chatLinks = document.querySelectorAll('.chat');

// Получаем основной контейнер для чата
var mainContent = document.querySelector('.main-content');

// Добавляем обработчик события для каждой ссылки чата
chatLinks.forEach(function(chatLink) {
    chatLink.addEventListener('click', function(event) {
        event.preventDefault(); // Предотвращаем переход по ссылке

        // Получаем значение атрибута data-city для определения выбранного чата
        var city = chatLink.getAttribute('data-city');

        // Очищаем содержимое основного контейнера чата
        mainContent.innerHTML = "";

        // В зависимости от выбранного города добавляем соответствующий контент в основной контейнер
        if (city === "Администратор") {
            mainContent.innerHTML = `
            <div class="chat-block">
                <div class="date-time" id="current-time"></div>
                <div class="chat-messages">
                    <div class="received-message">
                        <div>
                            <p>САЛЮТ! ВЫ ОСТАВЛЯЛИ ЗЯВКУ НА РАССМОТР ЗАКАЗА #34ННАЦ!</p>
                            <div class="picture">
                                <img src="../image/novinki/dgins.png" alt="Котенок">
                                <div class="address">
                                    <p>₽1900.00</p>
                                    <div class="line"></div>
                                    НИЖНИЙ НОВГОРОД, ДОМ 14,УЛ.КАЛАТУШКИНА, ПАДИК 4,КВ.1
                                </div>
                            </div>
                            <div class="opisanie">
                                <p>ЗАКАЗ УЖЕ СОБРАН И ОТПРАВЛЕН НА СДЕК. ВОЗМОЖНЫ ЗАДЕРЖКИ ГОЛУБЯМИ. ОЖИДАЙТЕ, ВАШ CRV !</p>
                            </div>
                        </div>
                    </div>
                    <div class="sent-message">
                        <p>ПРИВЕТ! СПАСИБО ЗА ИНФОРМАЦИЮ!</p>
                    </div>
                </div>
                <div class="message-input">
                    <input type="text" placeholder="Введите сообщение">
                    <a href="#" class="send-button">🡢</a>
                </div>
            </div>
            `;
        } else if (city === "Менеджер") {
            mainContent.innerHTML = `
            <div class="chat-block">
            <div class="date-time" id="current-time"></div>
            <div class="chat-messages">
                
                <div class="sent-message">
                    <p>ПРИВЕТ! ЕСТЬ ВОПРОСЫ ПО ЗАКАЗУ </p>
                </div>
            </div>
            <div class="message-input">
                <input type="text" placeholder="Введите сообщение">
                <a href="#" class="send-button">🡢</a>
            </div>
        </div>
            `;
        }

        // Дополнительные действия, если необходимо

    });
});