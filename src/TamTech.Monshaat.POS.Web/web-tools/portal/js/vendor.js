
var text ='<strong>@@</strong> has been successfully removed';
if(window.website.lang ==  'ar'){
   text = "تم حذف نظام <strong>@@</strong> من الموقع بنجاح"
} 
var alertTemplate = 
'<div class="alert alert-success alert-dismissible fade show no-radius" role="alert" id="alert-##">'+text+'<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>';
    
  


$('#DeletePosModal').on('show.bs.modal', function (event) {
   var $btn = $(event.relatedTarget);
   var pos_name = $btn.data("pos"); 
   var pos_url = $btn.data("url");
   var pos_id  = $btn.data('id');
   $('#delete-pos').attr('data-url',pos_url).attr('data-id',pos_id);
   $('#posName').text(pos_name) ;
});
$('#DeletePosModal').on('hidden.bs.modal', function () {
   $('#delete-pos').removeAttr('data-url data-id')
   $('#posName').text('') ;
});


$('#delete-pos').on('click',function(){
   var url = $(this).attr('data-url');
   var id =  $(this).attr('data-id');
   var txt = $('#posName').text();
   $.ajax({
      url: url , 
      type: "Get",             
      data: {},
      cache: false,              
      processData: false,      
      success: function(data) {
           if(data.success){
            $('#pos-'+id).remove();
            $(alertTemplate.replace('@@',txt).replace('##',id) ).insertBefore('.vendor-page');
            $('#DeletePosModal').modal('hide');
            setTimeout(function(){
               $('#alert-'+id).alert('close');
            },5e3);
            
           }
      }
  }); 
});