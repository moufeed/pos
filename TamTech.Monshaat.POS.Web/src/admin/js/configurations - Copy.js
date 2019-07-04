/*$(document).ready(() => {

    //------------------------------------------------------------------
    //#region #3 toggle atrribute status to update
    //------------------------------------------------------------------
    const inputTempValue = {};
    $(document).on('click', '.update-attrbute', function (e) {
        e.preventDefault();
        $(this).hide();
        let id = $(this).data('id');
        let inputName = $(`#Attribute-name-${id}`);
        inputTempValue[id] = inputName.val();
        inputName.removeAttr('disabled');
        $(`.save-attrbute[data-id="${id}"]`).removeClass('hidden');
    });
    //------------------------------------------------------------------
    //#endregion #3
    //------------------------------------------------------------------


    //------------------------------------------------------------------
    //#region #4 toggle attribute buttons and show error message
    //------------------------------------------------------------------
    const $toggleUpdateSaveButtons = ($this, inputName, id) => {
        $this.addClass('hidden');
        $(`.update-attrbute[data-id="${id}"]`).show();
        inputName.attr('disabled', 'disabled').removeClass('valid_field');
    }  


    $(document).on("click", ".update__config", function (event) {
        event.preventDefault();
        var $this = $(this),
            target = $this.data('target'),
            dataurl = $this.data('url'),
            error = $this.data('msg-error') || "Error!",
            deleted = $this.data('msg-updated') || "Updated successfully";

        $Confirm({}, function (result) {
            if (result.value) {
                $.ajax({
                    url: dataurl,
                    type: 'Get',
                    dataType: "json",
                    data: {}
                })
                    .done(function (data) {
                        if (data.success) {
                            $notification.success("", deleted, 2000, "fa fa-check");
                            $(target).remove();
                        } else {

                            var errors = data.errors;
                            if (errors.length > 0) {
                                txt = MakeErrorsMsg(errors);
                                $notification.error("", txt, 3500, "fa fa-exclamation-circle");
                            }
                        }
                    }).fail(function (jqXHR, Status) {
                        $notification.error(error, jqXHR.statusText, 2000, "fa fa-exclamation-circle");
                    });
            }
        });

    });  
   
}); //

 
*/


