// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    const rowCount = $("#list-product tr").length;
    if (rowCount === 0) {
        $("#cb-check-all").attr("disabled", true);
    }
    $(".btnDeleteClick").click(function () {
        const currentBtn = $(this);
        console.log(currentBtn.attr("id"));
        if (confirm("Do you delete?")) {
            $.ajax({
                url: `/Product/Delete?id=${currentBtn.attr("id")}`,
                method: "DELETE",
                success: function (data) {
                    console.log("Success Delete");
                    currentBtn.parent().parent().remove();
                }
            });
        }
    });
    $("#cb-check-all").change(function () {
        //console.log("check");
        if (this.checked) {
            $(".check-element").prop("checked", true);
        }
        else {
            $(".check-element").prop("checked", false);
        }
    });
    $("#btn-delete-check").click(function () {
        const selected = [];
        const selectedId = [];
        if (confirm("Ban Muon Xoa Cac Muc Da Chon")) {
            $(".check-element:checked").each(function () {
                selected.push($(this).attr("id").split("-")[1]);
                selectedId.push($(this).attr("id"));
                console.log(selected);
            });
            $.ajax({
                url: `/Product/DeleteByArrayId?ids=${selected}`,
                method: "DELETE",
                success: function (data) {
                    console.log("Success Delete");
                    for (let i = 0; i < selectedId.length; i++) {
                        console.log(selectedId[i]);
                        $(`#${selectedId[i]}`).parent().parent().remove();
                        const rowCountDelete = $("#list-product tr").length;
                        if (rowCountDelete === 0) {
                            $("#cb-check-all").attr("disabled", true);
                        }
                        $("#cb-check-all").prop("checked", false);
                    }
                }
            });
        }
    });
})