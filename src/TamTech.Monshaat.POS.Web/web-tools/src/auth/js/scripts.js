 
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
        $this.css('min-height', $fixedHeight);

}
 
$(window).on('resize', function () {
    if ($FixHeight) { 
        setTimeout(function () {
            $FixHeight.removeAttr("style");
            SetContentHeight();
        }, 150)

    }
})

  
$(function(){
    if ($FixHeight) {
        SetContentHeight();
    }

})