

var mainSwiper = new Swiper('.swiper-container', {
    speed: 800,
    spaceBetween: 0,
    init :false,
    
    autoplay: {
        delay: 5000,
      } 
}); 


 
mainSwiper.on("init slideChange", function(){
     
    var slide = $(mainSwiper.slides[mainSwiper.activeIndex]);

        slide.find('[data-animate]').each(function(i,item){

            $(item).addClass('animate');

            var Classs = 'animated ' + $(item).data("animate");

           setTimeout(function(){

            $(item).removeClass('animate').addClass(Classs);

            $(item).on('animationend', function() {
                $(item).removeClass(Classs);
             })

           },mainSwiper.params.speed)
        })
     
     
})

mainSwiper.init();