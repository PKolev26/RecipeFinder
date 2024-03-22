// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(document).ready(function () {

    var down = false;

    $('#bell').click(function (e) {

        var color = $(this).text();
        if (down) {

            $('#box').css('height', '0px');
            $('#box').css('opacity', '0');
            down = false;
        } else {

            $('#box').css('height', 'auto');
            $('#box').css('opacity', '1');
            down = true;

        }

    });

});
// Write your JavaScript code.
