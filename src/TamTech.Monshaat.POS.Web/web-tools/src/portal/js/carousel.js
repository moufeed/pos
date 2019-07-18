 if ($().owlCarousel) {
 
    const  LoadCarousel = ()=>{
        $('.owl-carousel').each( (index,_carousel)=> {
            var $carousel = $(_carousel);
            var  data = $carousel.data();
             
            let loop           = data.loop          ? data.loop         : false,
                margin         = data.margin        ? data.margin       : 10,
                nav            = data.nav           ? data.nav          : false,
                prev           = data.prev          ? data.prev         : '<i class="fas fa-chevron-left"></i>',
                next           = data.next          ? data.next         : '<i class="fas fa-chevron-right"></i>',
                dots           = data.dots          ? data.dots         : false,
                center         = data.center        ? data.center       : false,
                items          = data.items         ? data.items        : 6,
                autoplay       = data.autoplay      ? data.autoplay     : false,
                timeout        = data.timeout       ? data.timeout      : 5000,
                hoverPause     = data.pause         ? data.pause        : true,
                xsItems        = data.xsItems       ? data.xsItems      : 1,
                smItems        = data.smItems       ? data.smItems      : 2,
                mdItems        = data.mdItems       ? data.mdItems      : 3,
                lgItems        = data.lgItems       ? data.lgItems      : 6, 
                xlItems        = data.xlItems       ? data.xlItems      : 7 ,  
                rtl            = data.rtl           ? data.rtl          : false,
                owlOptions     = data.owlOptions    ? data.owlOptions   : false,
                slideBy        = data.slideby       ? data.slideby      : 1,
                singleItem     = data.singleitem    ? data.singleitem   : false;
    
                let options = {
                    autoplay                : autoplay,
                    autoplayTimeout         : timeout,
                    autoplayHoverPause      : hoverPause,
                    loop                    : loop,
                    margin                  : margin,
                    nav                     : nav,
                    dots                    : dots,
                    center                  : center,
                    navText                 : [prev,next],
                    rtl                     : rtl,
                    slideBy                 : slideBy 
            }
                    
            if(singleItem){
                options["items"] = 1;
            }else{
                options["items"] = items;
                options["responsive"] = {
                    0:{
                        items: xsItems 
                    },
                    576:{
                        items: smItems
                    },
                    768:{
                        items: mdItems
                    },
                    992:{
                        items: lgItems
                    },
                    1200:{
                        items: xlItems
                    }
                };
            }
     
            $carousel.owlCarousel( (owlOptions) ? owlOptions : options)
            
        })
    }
    LoadCarousel();
} 