 
  


$.validator.setDefaults({
    highlight: function(element) {
        $(element).addClass('is-invalid');
    },
    unhighlight: function(element) {
        $(element).removeClass('is-invalid');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function(error, element) {
        if(element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
}); 


$.validator.addMethod('phonenumber', function (value, element) {
    return this.optional(element) || /^\d{10}$/.test(value);
}, $.validator.messages.phonenumber)


$.validator.addMethod('zipcode', function (value, element) {
    return this.optional(element) || /^\d{5}$/.test(value);
}, $.validator.messages.zipcode)

$.validator.addMethod('mobileKSA', function (value, element) {
    return this.optional(element) || /^(((\+|00)+966)|0)+5+(\d{8})$/.test(value);
}, $.validator.messages.mobileKSA)


$.validator.addMethod( "fileMinimum", function( value, element, params ) {
    return $(element)[0].files.length >= params
}, $.validator.format( "Please attach at least {0} document(s)" ) );


$.validator.addMethod( "fileMaximum", function( value, element, params ) {
    return $(element)[0].files.length <= params
}, $.validator.format( "Please attach no more than {0} document(s)" ) );



$.validator.addMethod("checks", function(value, elem, param) {
    var $group = $($(elem).data('group'));
    return $group.find("input:checked").length > 0 ;
 }, $.validator.format( "You must select at least {0} item!"  ));  

$.validator.addClassRules("checks", {
    checks: 1
});


  

$.validator.addMethod( "commercial", function( value, element, params ) {
    return  value.length == params
}, $.validator.format( "Commercial number it has to be {0} digits" ));