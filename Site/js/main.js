//ПРИЛИПАЛО ХЕДЕР
window.onscroll = function() {stickyHeader()};

var header = document.querySelector("header");

function stickyHeader() {
  if (window.pageYOffset > 20) { // 20px - высота отступа
    header.classList.add("sticky");
  } else {
    header.classList.remove("sticky");
  }
}


//ФОРМА РЕГИСТРАЦИИ
document.addEventListener("DOMContentLoaded", function() {
  var loginLink = document.getElementById("login-link");
  var overlay = document.getElementById("overlay");
  var loginForm = document.getElementById("login-form");
  var registrationForm = document.getElementById("registration-form");
  var isLoginFormOpen = false; // Флаг для отслеживания состояния формы входа

  // Функция для открытия/закрытия формы входа
  function toggleLoginForm() {
    if (isLoginFormOpen) {
      overlay.style.display = "none";
      loginForm.style.display = "none";
      isLoginFormOpen = false;
    } else {
      // Если форма авторизации открыта, закрываем ее
      if (registrationForm.style.display === "block") {
        registrationForm.style.display = "none";
      }
      
      overlay.style.display = "block";
      loginForm.style.display = "block";
      isLoginFormOpen = true;
    }
  }

  document.addEventListener("click", function(event) {
    var target = event.target;
    // Проверяем, что клик был не на форме входа, на ссылке для открытия/закрытия формы,
    // и не на форме регистрации
    if (target !== loginForm && target !== loginLink && !loginForm.contains(target) &&
        target !== registrationForm && !registrationForm.contains(target)) {
      overlay.style.display = "none";
      loginForm.style.display = "none";
      registrationForm.style.display = "none";
      isLoginFormOpen = false;
    }
  });

  // Скрыть форму входа и оверлей при клике на оверлей
  overlay.addEventListener("click", function() {
    overlay.style.display = "none";
    loginForm.style.display = "none";
    isLoginFormOpen = false;
  });

  // Показать форму входа при клике на ссылку
  loginLink.addEventListener("click", function(event) {
    event.preventDefault();
    toggleLoginForm();
  });

  // Открыть форму регистрации при клике на кнопку "ЗАРЕГИСТРИРОВАТЬСЯ"
  var registrationButton = document.getElementById("registration-button");
  registrationButton.addEventListener("click", function(event) {
    event.preventDefault();
    overlay.style.display = "block";
    registrationForm.style.display = "block";
    
    // Закрываем форму входа при открытии формы регистрации
    if (isLoginFormOpen) {
      loginForm.style.display = "none";
      isLoginFormOpen = false;
    }
  });
});


//ФОРМА КАТАЛОГА
document.addEventListener("DOMContentLoaded", function() {
  var catalogLink = document.getElementById("catalog-link");
  var catalogForm = document.getElementById("catalog-form");
  var isCatalogOpen = false; // Флаг для отслеживания состояния каталога

  // Функция для открытия/закрытия каталога
  function toggleCatalog() {
    if (isCatalogOpen) {
      catalogForm.style.display = "none";
      isCatalogOpen = false;
    } else {
      catalogForm.style.display = "flex";
      isCatalogOpen = true;
    }
  }
  // Скрыть форму каталога при загрузке страницы
  catalogForm.style.display = "none";
  // Показать форму каталога при клике на ссылку
  catalogLink.addEventListener("click", function(event) {
      event.preventDefault();
      toggleCatalog();
  });
  // Скрыть форму каталога при клике вне ее области
  document.addEventListener("click", function(event) {
      var target = event.target;
      // Проверяем, что клик был не на форме каталога или на ссылке для открытия/закрытия формы
      if (target !== catalogForm && target !== catalogLink && !catalogForm.contains(target)) {
          catalogForm.style.display = "none";
          isCatalogOpen = false;
      }
  });
});



//ФОРМА ПОИСКА
document.addEventListener("DOMContentLoaded", function() {
  var searchLink = document.getElementById("search-link");
  var searchForm = document.getElementById("search-form");
  var isSearchOpen = false; // Флаг для отслеживания состояния формы поиска

  // Функция для открытия/закрытия формы поиска
  function toggleSearch() {
      if (isSearchOpen) {
          searchForm.style.display = "none";
          isSearchOpen = false;
      } else {
          searchForm.style.display = "block"; // Можно использовать любое другое значение, например, "flex"
          isSearchOpen = true;
      }
  }
  // Скрыть форму поиска при загрузке страницы
  searchForm.style.display = "none";
  // Показать форму поиска при клике на ссылку
  searchLink.addEventListener("click", function(event) {
      event.preventDefault();
      toggleSearch();
  });
  // Скрыть форму поиска при клике вне ее области
  document.addEventListener("click", function(event) {
      var target = event.target;
      // Проверяем, что клик был не на форме поиска или на самой ссылке для поиска
      if (target !== searchForm && target !== searchLink && !searchForm.contains(target)) {
          searchForm.style.display = "none";
          isSearchOpen = false;
      }
  });
});


//О РСВ ВЫПАДАЮЩИЙ СПИСОК
document.addEventListener("DOMContentLoaded", function() {
    var infoBlock = document.querySelector('.info-block');
    var dropdownContent = document.querySelector('.dropdown-content');

    infoBlock.addEventListener('click', function() {
        dropdownContent.classList.toggle('show');
        if (dropdownContent.classList.contains('show')) {
            // Добавляем отступ только при показе контента
            infoBlock.style.marginBottom = dropdownContent.offsetHeight + 100 + 'px';
        } else {
            infoBlock.style.marginBottom = '100px';
        }
    });
});