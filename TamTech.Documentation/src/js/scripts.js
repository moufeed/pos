  


$(document).ready(function(){
    $('body').scrollspy({ target: '#navbar-links' })


    //  $(window).on('activate.bs.scrollspy', function (e,obj) {
    //       console.log(obj.relatedTarget);
    //   });

    $('#navbar-links a,.article-headline-link ,.goto').on('click', function(event) {
        var target = $(this).attr('href');
        if( target.length ) {
            event.preventDefault(); 
            $('html, body').stop().animate({
                scrollTop: $(target).offset().top
            }, 600);
             
            setTimeout(function(){
                if( $(window).outerWidth() <= 991.98){
                    $('.docs-conteiner').addClass('closed');
                }
            },600)
        }
    });


    $('#menutoggle').on('click',function(){
        $('.docs-conteiner').toggleClass('closed');
    })

    var $sidebar = $('#sidebar ,#menutoggle');

    $(document).mouseup(function(e) {
        if (!$sidebar.is(e.target) && $sidebar.has(e.target).length === 0) 
            {
                $('.docs-conteiner').addClass('closed');
            }
    })
}) 