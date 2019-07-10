$(document).ready(() => {

    //------------------------------------------------------------------
    //#region #3 toggle atrribute status to update
    //------------------------------------------------------------------

    /*
    <a class="btn btn-update-link " data-id="sett-data-1">
        <i class="fa fa-pencil-square-o" aria-hidden="true"></i> @Localizer["edit"]
                                </a>

        <a class="btn btn-save-link save-setting " data-id="sett-data-1">
            <i class="fa fa-check" aria-hidden="true"></i>  @Localizer["save"]
                                </a>
    */
    const inputTempValue = {};
    $(document).on('click', '.edit-setting', function (e) {
        e.preventDefault();
        $(this).hide();
        let id = $(this).data('id');
        $(`.save-setting[data-id="${id}"]`).removeClass('hidden');
        $(`.cancel-setting[data-id="${id}"]`).removeClass('hidden'); 

        $(`.reset-setting[data-id="${id}"]`).hide();
        $(`.undo-setting[data-id="${id}"]`).hide(); 

        $(`.cancel-setting[data-id="${id}"]`).show();

        let inputDes = $(`#input-set-des-${id}`);//$(`#Attribute-name-${id}`);

        $(`#input-set-val-${id}`).removeAttr('disabled');
        $(`#input-set-des-${id}`).removeAttr('disabled');


        $(`.box-item[data-id="${id}"]`).addClass('box-editable'); 

    });




    $(document).on('click', '.cancel-setting', function (e) {
        e.preventDefault();
        $(this).hide();
        let id = $(this).data('id');
        $(`.save-setting[data-id="${id}"]`).addClass('hidden');
        $(`.cancel-setting[data-id="${id}"]`).addClass('hidden');

        $(`.edit-setting[data-id="${id}"]`).show();
        $(`.reset-setting[data-id="${id}"]`).show();
        $(`.undo-setting[data-id="${id}"]`).show();

        let inputKey = $(`#input-set-key-${id}`);//$(`#Attribute-name-${id}`);
      
        $(`#input-set-val-${id}`).attr('disabled', 'disabled');
        $(`#input-set-des-${id}`).attr('disabled', 'disabled');

        $(`.box-item[data-id="${id}"]`).removeClass('box-editable'); 

    });


    $(document).on('click', '.save-setting', function (e) {
        e.preventDefault();
        $('.update-setting').show();
        $(this).addClass('hidden');
        var dataurl = $(this).data('url');
        let id = $(this).data('id');
        let inputName = $(`#input-setting-1`);
        inputName.attr('disabled', 'disabled');
        $.ajax({
            url: dataurl,
            type: 'Post',
            dataType: "json",
            data: {}
        })
           .done(function (data) {
               if (data.result) {
                   inputName.val(data.result);
                $notification.success("", window.localization.deleted_successfully, 2000, "fa fa-check");
                $this.parents('tr[id="tr-' + id + '"]').remove();

            } else {
                var errors = data.errors;
                //if (errors.length > 0) {
                //let txt = MakeErrorsMsg(errors);
                //    $notification.error("", txt, 3500, "fa fa-exclamation-circle");
                //}
            }

        }
        ).fail(function (jqXHR, Status) {
            $notification.error(errorTitle, jqXHR.statusText, 2000, "fa fa-exclamation-circle");
        })  




       
    });


    /*
         $(this).hide();
        
        //$(`#Attribute-name-${id}`);
        
        inputName.removeAttr('disabled');
       // $(`.save-setting[data-id="${id}"]`).removeClass('hidden');
        $(`.save-setting[data-id="sett-data-1"]`).removeClass('hidden');
     */
    //------------------------------------------------------------------
    //#endregion #3
    //------------------------------------------------------------------



    //------------------------------------------------------------------
    //#region #3 toggle atrribute status to update
    //------------------------------------------------------------------
   
  /*
     $(document).on('click', '.save-setting', function (e) {
        e.preventDefault();
        console.log('hi..');
        $(this).hide();
        let id = $(this).data('id');
       let inputName = $(`#input-setting-1`);//$(`#Attribute-name-${id}`);
       inputTempValue[id] = inputName.val();
       inputName.attr('disabled', 'disabled');
        // $(`.save-setting[data-id="${id}"]`).removeClass('hidden');
       $(`.update-setting[data-id="sett-data-1"]`).show();

    });
   */
    //------------------------------------------------------------------
    //#endregion #3
    //------------------------------------------------------------------

   
}); //
