document.addEventListener("DOMContentLoaded", function () {
  const customerSelect = document.getElementById("customerSelect");

  function updateForm() {
    const forms = document.querySelectorAll(".add-to-cart-form");

    forms.forEach((form) => {
      const input = form.querySelector("input[name='id']");
      input.value = customerSelect.value;
    });
  }

  updateForm();
  customerSelect.addEventListener("change", updateForm);
});
