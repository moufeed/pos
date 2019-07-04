 document.documentElement.className = "js";

 var $FixHeight = $('[data-fix-height]');

 function SetContentHeight() {
     var $this = $FixHeight,
         $headerHeaight = $('.main-header').outerHeight(),
         $footerHeight = $('.main-footer').outerHeight(),
         $topFooter = ($('.top-footer').length > 0 ? $('.top-footer').outerHeight() + 50 : 0), // 50 =>  margen top
         $documentHeight = $(document).outerHeight(),
         $contentHeight = $this.outerHeight(),
         $totalHeight = $contentHeight + $headerHeaight + $footerHeight + $topFooter,
         $fixedHeight = $documentHeight - $headerHeaight - $footerHeight - $topFooter;
     if ($documentHeight > $totalHeight)
         $this.css('height', $fixedHeight);

 }

 $(window).on('resize', function () {
     if ($FixHeight) {
         setTimeout(function () {
             $FixHeight.removeAttr("style");
             SetContentHeight();
         }, 150)

     }
 })
 $(function () {
     if ($FixHeight) {
         SetContentHeight();
     }
     var offset = 250;
     var duration = 300;
     $(window).scroll(function (e) {
         if ($(this).scrollTop() > offset) {
             $(".back-to-top").fadeIn(duration);
         } else {
             $(".back-to-top").fadeOut(duration);
         }
     })
     $(".back-to-top").click(function (event) {
         event.preventDefault();
         $("html, body").animate({
             scrollTop: 0
         }, duration);
         return false;
     })
 
     $('[submit-on-enter]').keypress(function (e) {
         if (e.which == 13) {
             $(this).parents('form').submit();
             return false;
         }
     });

     $('[data-toggle="tooltip"]').tooltip();


     var  height = $('.main-header').outerHeight();
     
     var offset = 250 ,duration = 300;
     
     if(window.pageYOffset > 250 ){
         $('body').addClass('sticky_header').css('padding-top',height);
         $('.main-header').addClass('animated fadeInDown');
     }
 
     $(window).scroll(function(e){
         if(window.pageYOffset > 250 ){
             $('body').addClass('sticky_header').css('padding-top',height);
             $('.main-header').addClass('animated fadeInDown');
         }else{
             $('body').removeClass('sticky_header').css('padding-top',"0"); 
             $('.main-header').removeClass('animated fadeInDown');
         }
         
         if ($(this).scrollTop() > offset) {
             $(".back-to-top").fadeIn(duration);
         } else {
     
             $(".back-to-top").fadeOut(duration);
         }
 }) 

 })