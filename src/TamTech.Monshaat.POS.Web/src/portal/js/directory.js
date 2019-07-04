
function ChangeUrl(title, url) {
    if (typeof (history.pushState) != "undefined") {
        var obj = { Title: title, Url: url };
        history.pushState(obj, obj.Title, obj.Url);
    } else {
        alert("Browser does not support HTML5.");
    }
}
//window.onpopstate = function(event) { };


  

$(function () { 
   
    // filters sidebar
    var $sidebar = $('#filterSidebar');
    $('.btn-filter').on('click',function(){
        $sidebar.toggleClass("oppend")
    })
    $(document).mouseup(function(e) {
        if (!$sidebar.is(e.target) && $sidebar.has(e.target).length === 0) 
            {
                $sidebar.removeClass("oppend")
            }
    })


    // sector 
    /* $('.sector-link').on('click',function(event){
        event.preventDefault()
        var $this = $(this);
        ChangeUrl($this.data("slug"), $this.data("slug"));
        $('.sectors-widget .sector-link').removeClass('active');
        $this.addClass('active');
    }); */

    // filters
var $filters = $('#filtersForm');
$filters.find(':input').on('change',function(){
    var data = $filters.serialize();
    var url = $filters.data("action");
    $.ajax({
        url: url,
        data: data,
    })
    .done(function(data){
        $('#resultsList').html(data)
    })
    .fail(function() {
        console.log( "error" );
    })
    
})

$(document).on('click','.directory-pagination .page-link',function(event){
    event.preventDefault();
    var url = $(this).data('search');
    console.log(url)
    $.ajax({
        url: url
    })
    .done(function(data){
        $('#resultsList').html(data)
    })
    .fail(function() {
        console.log( "error" );
    })
})



 //---------------   
})
