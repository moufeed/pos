
if(window.website.lang ==  'ar'){
    $.extend( $.validator.messages, {
        required: "هذه الخانة مطلوبة",
        remote: "يرجى تصحيح هذه الخانة للمتابعة",
        email: "رجاء إدخال عنوان بريد إلكتروني صحيح",
        url: "رجاء إدخال عنوان موقع إلكتروني صحيح",
        date: "رجاء إدخال تاريخ صحيح",
        dateISO: "رجاء إدخال تاريخ صحيح (ISO)",
        number: "رجاء إدخال عدد بطريقة صحيحة",
        digits: "رجاء إدخال أرقام فقط",
        creditcard: "رجاء إدخال رقم بطاقة ائتمان صحيح",
        equalTo: "رجاء إدخال نفس القيمة",
        extension: "رجاء إدخال ملف بامتداد موافق عليه",
        maxlength: $.validator.format( "الحد الأقصى لعدد الحروف هو <b>{0}</b>" ),
        minlength: $.validator.format( "الحد الأدنى لعدد الحروف هو <b>{0}</b>" ),
        rangelength: $.validator.format( "عدد الحروف يجب أن يكون بين <b>{0}</b> و <b>{1}</b>" ),
        range: $.validator.format( "رجاء إدخال عدد قيمته بين <b>{0}</b> و <b>{1}</b>" ),
        max: $.validator.format( "رجاء إدخال عدد أقل من أو يساوي <b>{0}</b>" ),
        min: $.validator.format( "رجاء إدخال عدد أكبر من أو يساوي <b>{0}</b>" ),
        phonenumber : "رجاء إدخال رقم هاتف صحيح",
        accept : "رجاء اختر ملف من الصيغ المسموحة",
        maxWords : $.validator.format( " رجاء إدخال كلمات اقل من <b>{0}</b> كلمة" ),
        fileMaximum : $.validator.format( "رجاء تحميل <b>{0}</b> ملف على الاكثر" ),
        fileMinimum : $.validator.format( "رجاء تحميل <b>{0}</b> ملف  على الاقل" ),
        require_from_group : $.validator.format( "رجاء اختار <b>{0}</b> قطاع أو قم بكتابة اسم القطاع" ),
        checks : $.validator.format( "رجاء اختيار <b>{0}</b> عنصر على الاقل" ),
        mobileKSA : "رجاء إدخال رقم جوال صالح",
        zipcode : "رجاء إدخال رمز بريدي صالح",
        commercial : $.validator.format( "رقم السجل التجاري يجب ان يحتوي على  <b>{0}</b>  خانات" ),
        FileSize : $.validator.format( "حجم الملف يجب ان لايتجاوز <b>{0}</b> كيلو بايت" ),
        crvendor : $.validator.format( "رقم سجل غير صالح يرجى التاكد من الرقم" )
    } );
}  