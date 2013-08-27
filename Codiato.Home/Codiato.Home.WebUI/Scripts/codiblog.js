$(function () {
    $('#cute-blue-codiato-colored-line')
    .hover(
          function () {
              $(this).css('height', '40px');
              $('div#blog-menu').show();
          },
          function () {
              $('div#blog-menu').hide();
              $(this).css('height', '20px');
          }
        );
});