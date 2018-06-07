$('.right')
  .on('click', function() {
    console.log('right');
    $('.slide')
      .siblings('.active:not(:last-of-type)') 
      .removeClass('active')
      .next()
      .addClass('active');
});

$('.left')
  .on('click', function() {
    $('.slide')
      .siblings('.active:not(:first-of-type)')
      .removeClass('active')
      .prev()
      .addClass('active');
    });
var count = 0;
function slideshow(c) {
    if (c < 2) {
        $('.slide')
            .siblings('.active:not(:last-of-type)')
            .removeClass('active')
            .next()
            .addClass('active');
        c++;
    }
    if (c === 2) {
        c = 0;
    }
}
setTimeout(slideshow(count), 1000);