// Функция авторизации пользователя
function authorizeUser(targetPage) {
    const email = document.getElementById('email-input').value;
    const password = document.getElementById('password-input').value;
    
    fetch('http://192.168.45.250:3000/api/User/GetUsers')
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('API request failed');
            }
        })
        .then(data => {
            const user = data.find(user => user.user_email === email && user.user_password === password);
            if (user) {
                const id = user.id;
                const nickname = user.user_nickname;
                const city = user.user_city;
                const userEmail = user.user_email;
                const phone = user.user_phone;

                // Затем сохраняем данные в localStorage
                localStorage.setItem('id', id);
                localStorage.setItem('nickname', nickname);
                localStorage.setItem('city', city);
                localStorage.setItem('userEmail', userEmail);
                localStorage.setItem('phone', phone);

                // Уведомление об успешной авторизации
                alert('Вы успешно авторизовались');

                

                // После вывода уведомления переходим на целевую страницу
                window.location.href = `../html/${targetPage}`; // Передача id на страницу
            } else {
                alert('Неверный email или пароль');
            }
        })
        .catch(error => {
            console.error(error);
            alert('Произошла ошибка при авторизации');
        });
}

  
//РЕГИСТРАЦИЯ
function registerUser(targetPage) {
    let name = document.getElementById('registration-name-input').value;
    let surname = document.getElementById('registration-surname-input').value;
    let nickname = document.getElementById('registration-nick-input').value;
    let email = document.getElementById('registration-email-input').value;
    let phone = document.getElementById('registration-phone-input').value;
    let password = document.getElementById('registration-password-input').value;
    let city = document.getElementById('registration-city-input').value;
    
    var userData = {
        user_name: name,
        user_surname: surname,
        user_nickname: nickname,
        user_email: email,
        user_phone: phone,
        user_password: password,
        user_city: city // Добавляем значение города
    };
    
fetch('http://192.168.45.250:3000/api/User/AddUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
    })
    .then(response => {
        if (response.ok) {
            // Если регистрация успешна, перенаправляем пользователя на указанную страницу
            window.location.href = targetPage;
        } else {
            // Если произошла ошибка при регистрации, выводим сообщение об ошибке
            response.text().then(errorMessage => {
                console.error('Код ошибки сервера:', response.status);
                console.error('Текст ошибки:', errorMessage);
                alert('Произошла ошибка при регистрации');
            });
        }
    })
    .catch(error => {
        console.error('Ошибка:', error);
        alert('Произошла ошибка при отправке данных');
    
        // Дополнительная обработка ошибок
        if (error instanceof TypeError) {
            console.error('Ошибка TypeError: Возможно, проблема с соединением или адресом сервера.');
        } else if (error instanceof SyntaxError) {
            console.error('Ошибка SyntaxError: Проблема с парсингом ответа от сервера.');
        } else if (error instanceof NetworkError) {
            console.error('Ошибка NetworkError: Проблема с сетевым соединением.');
        }
    });
}
