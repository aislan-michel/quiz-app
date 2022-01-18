// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function goToQuestionDetails(questionId){
    window.location.href = `/Question/Details/${questionId}`;
}

function initCategorySelectList(selectedCategoryId){
    const url = "/category/get"; 
    
    $(document).ready(() => {
        $.get(url, (categories) => {
            let html = `<option selected disabled>Select one</option>`;

            categories.forEach(category => {
                if(utils.isEqual(category.value, selectedCategoryId)){
                    html += `<option selected value="${category.value}">${category.text}</option>`;   
                }else{
                    html += `<option value="${category.value}">${category.text}</option>`;
                }
            });

            $(".custom-select").html(html);
        });
    });
}

const utils = {
  isEqual: function isEqual(val1, val2){
      return val1 === val2;
  }
};

