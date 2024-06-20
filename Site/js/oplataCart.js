document.addEventListener("DOMContentLoaded", function() {
    var paymentLink = document.getElementById("payment-link");
    var overlay = document.getElementById("overlay");
    var paymentForm = document.getElementById("payment-form");
    var isPaymentFormOpen = false; // Флаг для отслеживания состояния формы оплаты
  
    // Функция для открытия/закрытия формы оплаты
    function togglePaymentForm() {
      if (isPaymentFormOpen) {
        overlay.style.display = "none";
        paymentForm.style.display = "none";
        isPaymentFormOpen = false;
      } else {
        overlay.style.display = "block";
        paymentForm.style.display = "block";
        isPaymentFormOpen = true;
      }
    }
    // Скрыть форму оплаты при загрузке страницы
    overlay.style.display = "none";
    paymentForm.style.display = "none";
  
    // Показать форму оплаты при клике на ссылку
    paymentLink.addEventListener("click", function(event) {
      event.preventDefault();
      togglePaymentForm();
    });
    // Скрыть форму оплаты при клике вне ее области
    document.addEventListener("click", function(event) {
      var target = event.target;
      // Проверяем, что клик был не на форме оплаты или на ссылке для открытия/закрытия формы
      if (target !== paymentForm && target !== paymentLink && !paymentForm.contains(target)) {
        overlay.style.display = "none";
        paymentForm.style.display = "none";
        isPaymentFormOpen = false;
      }
    });
});