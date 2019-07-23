function getGroups(form){
    let groups = {
        "nameGroup" :  "SectorId OtherSector"
    };
    let group = form.find("[data-group]");
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
    let $form = $('#createPosForm');
      
   let validator =  $form.validate({
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
           NewImage:{
            require_from_group :[1,".input-file"] 
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
             if ($(element).attr('name') == 'NewImage') {
                 $(element).closest(".box__input").addClass("is-invalid")
             }
             if ($(element).attr('name') == 'SectorId') {
                $(element).closest(".sectors_row").addClass("is-invalid")
            }
           
         },
         unhighlight: function (element) {
             $(element).removeClass('is-invalid');
             if ($(element).attr('name') == 'NewImage') {
                 $(element).closest(".box__input").removeClass("is-invalid")
             }
             if ($(element).attr('name') == 'SectorId') {
                $(element).closest(".sectors_row").removeClass("is-invalid")
            }
         },
         errorPlacement: function (error, element) {
             if (element.attr('name') == 'NewImage') {
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

    let $inputs =  $form.find('div.attribute').find('input[type="checkbox"],input[type="radio"]');
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
    let $this = $(this);
    let action = $this.data('href');
    let image = $this.data('image');
    let target = $this.data('target');
    let _uploadedfiles = $('#UploadedFiles');
    let _attachments = $("#addImages");
    let _ImagesCount = $("#ImagesCount");
    let oldval = _uploadedfiles.val();
    $.ajax({
        url: action , 
        type: "POST",             
        data: {'img' : image},
        cache: false,             
        success: function(data) {
            if(data.success){
                let max=  parseInt(_attachments.attr("data-maximages")) + 1;
                
                $('.box__input').removeClass("disabled");
                $(target).remove();
                let list = oldval.split(";;");
                let indx =  list.findIndex(function(el){ return el == image })
                list.splice(indx,1);
                _uploadedfiles.val(list.join(';;'))
               /*  _attachments.rules('add', {fileMaximum   : max <= 8 ? max : 8} );
                _attachments.attr("data-rule-filemaximum", max <= 8 ? max : 8 ); */
                _attachments.attr("data-maximages", max <= 8 ? max : 8 );
                _attachments.removeAttr("disabled");
                _ImagesCount.text(max);
            } 
        }
    }); 
 })


 let $index = 0;

 $(document).on('change','#addImages', function () {
    let $el = $(this);
    let $clone = $el.clone();
    let maximages = parseInt($el.data('maximages'));
     if(this.files && this.files[0]){
        $clone.attr('id' , `input-${$index}` ).attr('name', `Attachments[]`).removeClass().addClass('input-file') ;
        $clone.appendTo('#inputsfiles');
       
        $("#files-info").append(`<li id="file-${$index}">
                <i class="far fa-file file-icon"></i> <p class="file-info">
                    <strong>${this.files[0].name}</strong>
                    <small dir="ltr">${(this.files[0].size / 1024).toFixed(2)} MB</small>
                </p>
                <button class="btn btn-link btn-remove-file btn-file-cancel" data-id="${$index}"><i class="fas fa-times"></i></button>
            </li>`);
      
        $el.wrap('<form>').closest('form').get(0).reset();
        $el.unwrap();
        $index++;
        if($index == maximages ){
            $el.attr('disabled' ,'disabled')
            $(".box__input").addClass('disabled');
        }
    }
})

$(document).on('click','.btn-remove-file',function(event){
    event.preventDefault()
    let $id = $(this).data('id');
    $(`#file-${$id},#input-${$id}`).remove();
    $index = $index > 0 ? $index - 1 : 0;
    $('#addImages').removeAttr('disabled');
    $(".box__input").removeClass('disabled');
})