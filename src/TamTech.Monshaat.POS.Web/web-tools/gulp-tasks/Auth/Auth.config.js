const auth_dist = "./wwwroot/auth";
const auth_src = "./web-tools/src/auth";




let ListFiles = [{
    output: "validation.js",
    es6: false,
    inputs: [
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation/dist/additional-methods.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './node_modules/jquery-validation/dist/localization/messages_ar.min.js'
    ]
}, {
    output: "script.js",
    es6: true,
    inputs: [
        `${auth_src}/js/scripts.js`
    ]
}   
];
 
//---------------------------------------- DEFAULT OPTIONS
let header = '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n';

let DefaultOptions = {
    dist: auth_dist,
    header: header,
    src: auth_src
};

//---------------------------------------- SASS OPTIONS
let SassOptions = {
    outputStyle: 'compressed'
};

//---------------------------------------- STYLE OPTIONS
let cssOptions = {
    dist: `${auth_dist}/css/`,
    src: [
        `${auth_src}/scss/**/*.scss`
    ]
};

//---------------------------------------- JAVSCRIPT OPTIONS
let jsOptions = {

    dist: `${auth_dist}/js`,
    watch: `${auth_src}/js/**/*.js`,
    files: ListFiles
};


//---------------------------------------- MODULE EXPORTS
module.exports = {
    ...DefaultOptions,
    sassOptions: { ...SassOptions },
    css: { ...cssOptions },
    js: { ...jsOptions }
};