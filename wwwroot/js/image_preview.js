$(document).ready(function () {
    $('#FormFile').on('change', function () {
        $('.img-preview').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
    });
});