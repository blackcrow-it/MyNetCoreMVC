// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
    $(".btnDeleteClick").click(function() {
        const currentBtn = $(this);
        console.log(currentBtn.attr("id"));
        if (confirm("Do you delete?")) {
            $.ajax({
                url: `Delete?id=${currentBtn.attr("id")}`,
                method: "DELETE",
                success: function(data) {
                    console.log("Success Delete");
                    currentBtn.parent().parent().remove();
                }
        });
        }
    });
})