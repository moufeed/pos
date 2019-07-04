const admin_dist = "./wwwroot/admin";
const admin_src = "./web-tools/src/admin";




let ListFiles = [{
        output: "validation.js",
        es6: false,
        inputs: [
            './node_modules/jquery-validation/dist/jquery.validate.min.js',
            './node_modules/jquery-validation/dist/additional-methods.js',
            './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
            './node_modules/jquery-validation/dist/localization/messages_ar.min.js'
        ]
    },{
        output: "script.js",
        es6: true,
        inputs: [
            `${admin_src}/js/Localization.js`,
            `${admin_src}/js/scripts.js`,
        ],
    },
    {
        output: "serializejson.js",
        inputs: [
            './node_modules/jquery-serializejson/jquery.serializejson.min.js',
        ],
    },
    {
        output: "Localization.js",
        es6: true,
        inputs: [
            `${admin_src}/js/Localization.js`
        ],
    },{
        output: "users.js",
        inputs: [
            `${admin_src}/js/users.js`
        ],
    }, {
        output: "validator.js",
        inputs: [
            
            `${admin_src}/js/validator.js`
        ],
    }, {
        output: "menu.js",
        es6: true,
        inputs: [
            `${admin_src}/js/menu.js`
        ],
    }, {
        output: "sliders.js",
        es6: false,
        inputs: [
            `${admin_src}/js/sliders.js`
        ],
    }, {
        output: "services.js",
        es6: true,
        inputs: [
            `${admin_src}/js/services.js`
        ],
    },  
    {
        output: "seo.js",
        es6: true,
        inputs: [
            `${admin_src}/js/seo.js`
        ],
    },
    {
        output: "pages.js",
        es6: true,
        inputs: [
            `${admin_src}/js/pages.js`
        ],
    },
    {
        output: "sectors.js",
        es6: true,
        inputs: [
            `${admin_src}/js/sectors.js`
        ],
    },
    {
        output: "message.js",
        es6: true,
        inputs: [
            `${admin_src}/js/message.js`
        ],
    }, {
        output: "pos.js",
        es6: true,
        inputs: [
            `${admin_src}/js/pos.js`
        ],
    
    }, {
        output: "vendor.js",
        es6: true,
        inputs: [
            `${admin_src}/js/vendor.js`
        ]
    }, {
        output: "attributes.js",
        es6: true,
        inputs: [
            `${admin_src}/js/attributes.js`
        ]
    }, {
        output: "values.js",
        es6: true,
        inputs: [
            `${admin_src}/js/values.js`
        ]

    }, {
        output: "chart.js",
        es6: false,
        inputs: [
            './node_modules/chart.js/dist/Chart.min.js',
            `${admin_src}/js/charts.js`
        ]
    },{
        output: "regions.js",
        es6: false,
        inputs: [
            `${admin_src}/js/regions.js`
        ]
    },{
        output: "homepage.js",
        es6: true,
        inputs: [
            `${admin_src}/js/homepage.js`
        ]
    },{
        output: "tagify.js",
        es6: false,
        inputs: [
            `./node_modules/@yaireo/tagify/dist/tagify.js`
        ]
    }
]
 
//---------------------------------------- DEFAULT OPTIONS
let header = '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n';

let DefaultOptions = {
    dist: admin_dist,
    header: header,
    src: admin_src,
}

//---------------------------------------- SASS OPTIONS
let SassOptions = {
        outputStyle: 'compressed'
}

//---------------------------------------- STYLE OPTIONS
let cssOptions = {
    dist: `${admin_dist}/css/`,
    src: [
        `${admin_src}/scss/**/*.scss`
    ],
}

//---------------------------------------- JAVSCRIPT OPTIONS
let jsOptions = {

        dist: `${admin_dist}/js`,
        watch: `${admin_src}/js/**/*.js`,
        files: ListFiles
}


//---------------------------------------- MODULE EXPORTS
module.exports = {
    ...DefaultOptions,
    sassOptions :{ ...SassOptions},
    css :{...cssOptions},
    js :{ ...jsOptions }
}