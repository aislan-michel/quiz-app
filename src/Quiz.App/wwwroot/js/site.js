// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function goToQuestionDetails(questionId){
    window.location.href = `/Question/Details/${questionId}`;
}

function generateShareUrl(scoreId){
    const url = `localhost:5001/Share/Score/${scoreId}`;
    const toShared = `https://www.facebook.com/sharer/sharer.php?u=${url}`;

    window.open(toShared, "_blank");
}