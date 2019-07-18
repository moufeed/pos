

let mainSwiper = new Swiper('.swiper-container', {
    speed: 800,
    spaceBetween: 0,
    init :false,
    
    autoplay: {
        delay: 5000,
      } 
}); 


 
mainSwiper.on("init slideChange", ()=>{
     
  let slide = $(mainSwiper.slides[mainSwiper.activeIndex]);

        slide.find('[data-animate]').each((i,item)=>{

            $(item).addClass('animate');

            let Classs = 'animated ' + $(item).data("animate");

           setTimeout(()=>{

            $(item).removeClass('animate').addClass(Classs);

            $(item).on('animationend', ()=> {
                $(item).removeClass(Classs);
             })

           },mainSwiper.params.speed)
        })
     
     
})

mainSwiper.init();