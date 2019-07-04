$(document).ready(function(){
 
    $('.check').on('change',function(){
        var $this = $(this);
        var mandatory = $this.data('note');
        if(mandatory){
            $('.action_note').addClass("required");
        }else{
            $('.action_note').removeClass("required");
        }
        $('.action_note').valid();
    })
   if($.fn.validate){
    $('#actionform').validate({
        errorClass: "invalid_field",
        validClass: "valid_field",
        ignore: ".ignore",
        errorPlacement: function (error, element) {
            if (element.attr('name') == 'ActionId') {
                error.appendTo('.actionId-errors');
                return;
            }  else { 
                error.insertAfter(element);
            }
        },
        submitHandler:function(form){
            var action = $(form).attr("action");
            
            $.ajax({
                url: action , 
                type: "POST",             
                data: $(form).serialize(),
                cache: false,              
                processData: false,      
                success: function(data) {
                    if(data.success){
                        $('#actionform').trigger("reset");
                        $notification.success("",window.localization.processed_successfully, 2000, "fa fa-check");
                        $('#statustext').html('<span class="badge badge-'+data.result.vendor.statusOptions+'">'+data.result.vendor.statusName+'</span>' );
                           if(data.result.vendor.activated){
                             $('#published').html('<span class="c-green"><i class="fa fa-check" aria-hidden="true"></i>'+window.localization.active+'</span>');
                         }else{
                            $('#published').html('<span class="c-red"><i class="fa fa-times" aria-hidden="true"></i>'+window.localization.inactive+'</span>');
                         }   
                    }else{
                        var errors = data.errors;
                        if (errors.length > 0) {
                            txt = MakeErrorsMsg(errors);
                            $notification.error("", txt , 3500, "fa fa-exclamation-circle");
                        }
                    }
                }
            }); 
            return false;
        }
    })
   }
  


$('.toggle__Activate').on('change',function(){
    var $this =$(this);
    var status = $this.prop("checked");
    var data = $this.data();
    var history = data.history ;
    
    $Confirm({
        title:  window.localization.confirm_title,
        text:    (status) ? data.unblockMsg : data.blockMsg  ,
        type: (status) ? 'success' :'error',
    },function(result){
        if (result.value) {
              
            $.ajax({
                url: data.url , 
                type: "POST",             
                data:{
                    'Name' : data.id,
                    'Checked' : status,
                    'Id' : $this.attr('id')
                },
                success: function(res) {
                    if(res.success){
                        $notification.success(window.localization.success,(status) ? data.unblockedMsg : data.blockedMsg , 2000, "fa fa-check");
                        refreshHistory(history);
                    }else{
                        $this.prop("checked",!status)
                        var errors = res.errors;
                        if (errors.length > 0) {
                            txt = MakeErrorsMsg(errors);
                            $notification.error("", txt , 3500, "fa fa-exclamation-circle");
                        }
                    }
                }
            }); 
        }else{
            $this.prop("checked",!status)
        }
    })
})


})

function refreshHistory(url){
    $.get(url, function( data ) {
        $( "#history" ).html( data );
      });  
} 