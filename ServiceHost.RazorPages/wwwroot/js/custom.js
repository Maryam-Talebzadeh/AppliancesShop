var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            alert("خطایی رخ داده، لطفا با مدیر سیستم تماس بگیرید.");
        });
};

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).on("submit",
'form[data-ajax="true"]',
function (e) {
    e.preventDefault();
    var form = $(this);
    const method = form.attr("method").toLocaleLowerCase();
    const url = form.attr("action");
    var action = form.attr("data-action");

    if (method === "get") {
        const data = form.serializeArray();
        $.get(url,
            data,
            function (data) {
                CallBackHandler(data, action, form);
            });
    } else {
        var formData = new FormData(this);
        $.ajax({
            url: url,
            type: "post",
            data: formData,
            enctype: "multipart/form-data",
            dataType: "json",
            processData: false,
            contentType: false,
            success: function (data) {
                CallBackHandler(data, action, form);
            },
            error: function (data) {
                alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
            }
        });
    }
    return false;
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSuccedded) {
                window.location.reload();
            } else {
                alert(data.message);
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}