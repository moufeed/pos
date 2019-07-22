
var $form    = $(document).find("form");


var $zone    = $form.find('.box__input'),
$input       = $form.find('input[type="file"]'),
$label       = $form.find('.file-btn'),
droppedFiles = false,
appendText   = function (files){  return files.length > 1 ? ( $input.data( 'multiple-caption' ) || '' ).replace( '{count}', files.length ) : files[ 0 ].name },
showFiles    = function (files){  $label.text( files.length > 0 ? appendText(files) : $label.data("text") ); }


$input.on('change', function(e) {
showFiles(e.target.files);
});


/*
//   Remember This
//  There is no cross-browser way to upload dragged & dropped files without Ajax. Some browsers (IE and Firefox)
//  do not allow setting the value of a file input, which then could be submitted to server in a usual way

$zone.on( 'drag dragstart dragend dragover dragenter dragleave drop', function( e )
{
    e.preventDefault();
    e.stopPropagation();
})
.on( 'dragover dragenter', function()  
{
    $zone.addClass( 'is-dragover' );
})
.on( 'dragleave dragend drop', function()
{
    $zone.removeClass( 'is-dragover' );
})
.on( 'drop', function( e )
{
    droppedFiles = e.originalEvent.dataTransfer.files;  
    showFiles( droppedFiles );
    $input.prop("files", droppedFiles);
});
*/