$('#form-reply').validate({
    errorClass: "invalid_field",
    validClass: "valid_field",
    ignore: ".ignore",
    submitHandler: function (form) {
        var action = $(form).attr("action");
        
        $.ajax({
            url: action , 
            type: "POST",             
            data: $(form).serialize(),
            cache: false,             
            processData: false,      
            success: function(data) {
                if(data.success){
                    window.location.reload();
                }else{
                    var errors = data.errors;
                    if (errors.length > 0) {
                       let txt = MakeErrorsMsg(errors);
                        $notification.error("", txt , 3500, "fa fa-exclamation-circle");
                    }
                }
            }
        }); 
        return false;
    }
});


if($.fn.validate){
    $('#form-reply').validate();
}