
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
        maxlength: $.validator.format( "الحد الأقصى لعدد الحروف هو {0}" ),
        minlength: $.validator.format( "الحد الأدنى لعدد الحروف هو {0}" ),
        rangelength: $.validator.format( "عدد الحروف يجب أن يكون بين {0} و {1}" ),
        range: $.validator.format( "رجاء إدخال عدد قيمته بين {0} و {1}" ),
        max: $.validator.format( "رجاء إدخال عدد أقل من أو يساوي {0}" ),
        min: $.validator.format( "رجاء إدخال عدد أكبر من أو يساوي {0}" ),
        phonenumber : "رجاء إدخال رقم هاتف صحيح",
        accept : "رجاء اختر ملف من الصيغ المسموحة",
        maxWords : $.validator.format( " رجاء إدخال كلمات اقل من {0} كلمة" ),
        fileMaximum : $.validator.format( "رجاء تحميل {0} ملف على الاكثر" ),
        fileMinimum : $.validator.format( "رجاء تحميل {0} ملف  على الاقل" ),
        require_from_group : $.validator.format( "رجاء اختار {0} قطاع أو قم بكتابة اسم القطاع" ),
        checks : $.validator.format( "رجاء اختيار {0} عنصر على الاقل" ),
        mobileKSA : "رجاء إدخال رقم جوال صالح",
        zipcode : "رجاء إدخال رمز بريدي صالح"
    } );
}   