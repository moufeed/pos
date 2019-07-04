$(document).ready(function(){

    
    $(document).on("click",".delete-pos",function(event){
        event.preventDefault();
        var $this = $(this);
        var dataurl = $this.data('url');
        var id = $this.data('id')
        $Confirm({},function(result){
            if (result.value) {
                $.ajax({
                    url: dataurl ,
                    type: 'Get',
                    dataType: "json",   
                    data: {}
                })
                .done(function(data){
                    if(data.success){
                        $notification.success("",window.localization.deleted_successfully , 2000, "fa fa-check");
                        $this.parents('tr[id="tr-'+id+'"]').remove();
                   
                    }else{ 
                        var errors = data.errors;
                            if (errors.length > 0) {
                                txt = MakeErrorsMsg(errors);
                                $notification.error("", txt , 3500, "fa fa-exclamation-circle");
                            } 
                    }
   
                 }
            ) .fail(function (jqXHR, Status) {
                $notification.error(errorTitle, jqXHR.statusText, 2000, "fa fa-exclamation-circle");
            })  
            }
        })
    })
 

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
            var history = $(form).data('history');
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
                         $('#statustext').text(data.result.statusName);
                         if(data.result.published){
                             $('#published').html('<span class="c-green"><i class="fa fa-check" aria-hidden="true"></i>'+window.localization.published+'</span>');
                         }else{
                            $('#published').html('<span class="c-red"><i class="fa fa-times" aria-hidden="true"></i>'+window.localization.unpublished+'</span>');
                         }
                         refreshHistory(history);
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
   
})

function refreshHistory(url){
    $.get(url, function( data ) {
        $( "#history" ).html( data );
      });  
} 