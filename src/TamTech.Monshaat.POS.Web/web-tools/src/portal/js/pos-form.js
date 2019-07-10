function getGroups(form){
    var groups = {
        "nameGroup" :  "SectorId OtherSector"
    };
    var group = form.find("[data-group]");
    if(group.length){
        group.each(function(i,item){
            if( groups[$(item).data('group')]  === undefined){
                groups[$(item).data('group')] =  $(item).attr('name');
            }else{
                groups[$(item).data('group')] +=  " "+$(item).attr('name');
            }
        }) 
    }
  
    return groups;

}
 $(function () { 
    var $form = $('#createPosForm');
      
   var validator =  $form.validate({
         errorClass: "invalid-feedback",
         validClass: "valid-feedback",
         ignore: ".ignore",
         groups:  getGroups($form),
         rules: {
            SectorId: {
                require_from_group :[1,".sectors"]                
           },
           OtherSector: { 
                require_from_group :[1,".sectors"]
           },
           Name :{
            remote :{
                url: $('#Name').data("remote") , 
                type: "post",
                data:{
                    Name : function(){
                        return $('#Name').val();
                    } ,
                    Id : function(){
                        return $('#Name').data('id');
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
             if ($(element).attr('name') == 'SectorId') {
                $(element).closest(".sectors_row").addClass("is-invalid")
            }
         },
         unhighlight: function (element) {
             $(element).removeClass('is-invalid');
             if ($(element).attr('name') == 'Attachments') {
                 $(element).closest(".box__input").removeClass("is-invalid")
             }
             if ($(element).attr('name') == 'SectorId') {
                $(element).closest(".sectors_row").removeClass("is-invalid")
            }
         },
         errorPlacement: function (error, element) {
             if (element.attr('name') == 'Attachments') {
                 error.appendTo('.Attachments-errors');
                 return;
             } 
             else if(element.attr('name') == 'SectorId'){
                error.appendTo('.sectors-error');
                return;
            }
            else if(element.is("[data-attribute]")){
                    element.parents('.options-list').find('.options-errors').append(error)
                    return;
            }
             else {
                 error.insertAfter(element);
             }
         }
     })
   
  
 
     //select 
     if ($.fn.select2 && $(".select-list").length) {
         $(".select-list").select2({
             theme: "bootstrap4",
             minimumResultsForSearch: -1,
         });
     }
 

     // show clear btn 

    var $inputs =  $form.find('div.attribute').find('input[type="checkbox"],input[type="radio"]');
        $inputs.on('change',function(){
          let  $container = $(this).parents('div.attribute');
            $container.find('.btn-opt-cancel').show();
        })
        
    //  clear options ----------------

    $('.btn-opt-cancel').on('click',function(){
        let $container = $(this).parents('div.attribute');
        $container.find('input[type="checkbox"],input[type="radio"]').each(function(){
            $(this).prop("checked" ,false)
            $(this).valid();
        })
        $(this).hide();
    })
 });


 $('#OtherSector').on('change',function(){
    if($(this).val().length > 0){
        $('[name="SectorId"]').prop("checked" ,false);
    }
 })

 $('[name="SectorId"]').on('change',function(){
    $("#OtherSector").val('');
 })

 $('.delete-image').on('click',function(){
    var $this = $(this);
    var action = $this.data('href');
    var image = $this.data('image');
    var target = $this.data('target');
    var _uploadedfiles = $('#UploadedFiles');
    var _attachments = $("#Attachments");
    var _ImagesCount = $("#ImagesCount");
    var oldval = _uploadedfiles.val();
    $.ajax({
        url: action , 
        type: "POST",             
        data: {'img' : image},
        cache: false,             
        success: function(data) {
            if(data.success){
                var max=  parseInt(_attachments.attr("data-rule-filemaximum")) + 1;
                $('.box__input').removeClass("disabled");
                $(target).remove();
                var list = oldval.split(";;");
                var indx =  list.findIndex(function(el){ return el == image })
                list.splice(indx,1);
                _uploadedfiles.val(list.join(';;'))
                _attachments.rules('add', {fileMaximum   : max <= 8 ? max : 8} );
                _attachments.attr("data-rule-filemaximum", max <= 8 ? max : 8 );
                _attachments.removeAttr("disabled");
                _ImagesCount.text(max);
            } 
        }
    }); 
 })
