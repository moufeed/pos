$(function () {
    var $form = $('#createVendorForm');

    var validator = $form.validate({
        errorClass: "invalid-feedback",
        validClass: "valid-feedback",
        ignore: ".ignore",
        groups:{},
        rules: {
            CompanyName :{
                    remote :{
                        url: $('#CompanyName').data("remote") , 
                        type: "post",
                        data:{
                            Name  : function(){
                                return $('#CompanyName').val();
                            },
                            Id : function(){
                                return $('#CompanyName').data('id');
                            }
                        } 
                    }
               },
               CommercialNo :{
                remote :{
                    url: $('#CommercialNo').data("remote") , 
                    type: "post",
                    data:{
                        number  : function(){
                            return $('#CommercialNo').val();
                        },
                        Id : function(){
                            return $('#CommercialNo').data('id');
                        }
                    } 
                }
           }
         },
        highlight: function (element) {
            $(element).addClass('is-invalid');
            if ($(element).attr('name') == 'Attachments') {
                $(element).closest(".box__input").addClass("is-invalid")
            }
        },
        unhighlight: function (element) {
            $(element).removeClass('is-invalid');
            if ($(element).attr('name') == 'Attachments') {
                $(element).closest(".box__input").removeClass("is-invalid")
            }
        },
        errorPlacement: function (error, element) {
            if (element.attr('name') == 'Attachments') {
                error.appendTo('.Attachments-errors');
                return;
            } else {
                error.insertAfter(element);
            }
        }
    })
})