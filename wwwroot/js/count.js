$(document).ready(function () {
    $.ajax(
        {
            url: '/Cart/Count',
            success: function (count) {
                console.log(count);
                $('#cartCount').text(count);
            },
            error: function () {
                alert('errorrr!!');
            },
        });
});