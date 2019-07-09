
var loadGrecaptcha = function(val) {
        grecaptcha.render('grecaptcha', {
        'sitekey' : '6LfByKwUAAAAAHPhLqsK4ifj93GyiH4d9h7DcJar'
    });
    };

var RecaptchaCallback = function(){
    $('#hiddenRecaptcha').val(true).valid()
}







var $form = $('#contact-form');
 
$form.validate(
    { 
          errorClass: "invalid-feedback",
          validClass: "valid-feedback",
          ignore: ".ignore",
          rules:{
            PhoneNumber:{
                mobileKSA :true
            },
             hiddenRecaptcha: {
                required: function () {
                    if (grecaptcha.getResponse() == '') 
                        return true;
                    return false;                     
                }
            }  
          },
          errorPlacement :function(error,element){
            if(element.attr('name') == 'Attachments'){
                error.appendTo('.Attachments-errors');
                return;
            }else{
                error.insertAfter(element);
            }
          }
             
    }
);

  


var oldTargets="";

function toggleOptions(options){
    var targets =[];
    
    for (var key in options) {
            if(options[key]){
                targets.push("[data-id='"+key+"']")
            }
    } 
 
    if(targets.length > 0){
        if(oldTargets.length > 0){
            toggleBox(oldTargets, false);
        }
        oldTargets = targets.join();
        toggleBox(targets.join(), true)
    }else{
        toggleBox(oldTargets, false)
    }

    
}
 
$('select[data-change]').on('change',function(){
    var options= $(this)
                .find("option:selected")
                .data('options');
    toggleOptions(options);
})

function toggleBox(conteiners,status){
        
    if($(conteiners).length){
    if(status){
        $(conteiners).removeClass('d-none');
        $(conteiners)
        .find('[data-required]')
        .attr('required','required')
        .removeClass('ignore');
    }else{
        
        $(conteiners).addClass('d-none');
        $(conteiners).find("input,select").val('');
        var $el = $(conteiners).find('input[type="file"]');
        $el.wrap('<form>')
        .closest('form')
        .get(0)
        .reset();
        $el.unwrap();

        showFiles($el[0].files);

        $(conteiners)
        .find('[data-required]')
        .removeAttr('required')
        .removeClass('is-invalid')
        .addClass('ignore');
    }
}
}


// show data  after return to view 
$(document).ready(function(){
    setTimeout(function(){
        var options= $('select[data-change]')
                    .find("option:selected")
                    .data('options');
        toggleOptions(options);
        if($('input[type="file"]')[0].files){
            showFiles($('input[type="file"]')[0].files)
        }
    },500)
})

//select 
if($.fn.select2 && $(".select-list").length){
    $(".select-list").select2({
        theme: "bootstrap4",
        minimumResultsForSearch: -1
    });
} 