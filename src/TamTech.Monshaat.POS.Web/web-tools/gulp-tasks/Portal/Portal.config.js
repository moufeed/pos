const portal_dist = "./wwwroot/portal";
const portal_src = "./web-tools/src/portal";



let ListFiles = [
    {
        output: "script.js",
        es6: true,
        inputs: [
            `${portal_src}/js/scripts.js`
        ]
    },{
        output: "slider.js",
        es6: true,
        inputs: [
            './node_modules/swiper/dist/js/swiper.min.js',
            `${portal_src}/js/slider.js`
        ]
    },{
        output: "validation.js",
        es6: false,
        inputs: [
            './node_modules/jquery-validation/dist/jquery.validate.min.js',
            './node_modules/jquery-validation/dist/additional-methods.js',
            `${portal_src}/js/jquery-validation-methods.js`,
            `${portal_src}/js/jquery-validation-localizatio.js`
        ]
    },{
        output: "contactus.js",
        es6: true,
        inputs: [
            `${portal_src}/js/Upload.js`,
            `${portal_src}/js/contactus.js`
        ]
    },{
        output: "carousel.js",
        es6: true,
        inputs: [
            './node_modules/owl.carousel/dist/owl.carousel.min.js',
            `${portal_src}/js/carousel.js`
        ]
    },{
        output: "directory.js",
        es6: true,
        inputs: [ 
             `${portal_src}/js/directory.js`
        ]
    },{
        output: "pos.f.js",
        es6: true,
        inputs: [
            `${portal_src}/js/Upload.js`,
             `${portal_src}/js/pos-form.js`
        ]
    },
    {
        output: "vendor.f.js",
        es6: true,
        inputs: [
             `${portal_src}/js/vendor-form.js`
        ]
    },
    {
        output: "vendor.js",
        es6: true,
        inputs: [
             `${portal_src}/js/vendor.js`
        ]
    }
];


//---------------------------------------- DEFAULT OPTIONS
let header = '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n';
let DefaultOptions = {
    dist: portal_dist,
    header: header,
    src: portal_src,
}
//---------------------------------------- SASS OPTIONS
let SassOptions = {
    outputStyle: 'compressed'
}

//---------------------------------------- STYLE OPTIONS
let cssOptions = {
    dist: `${portal_dist}/css/`,
    src: [
        `${portal_src}/scss/**/*.scss`
    ],
}
//---------------------------------------- JAVSCRIPT OPTIONS
let jsOptions = {
    dist: `${portal_dist}/js`,
    watch: `${portal_src}/js/**/*.js`,
    files: ListFiles
}


let fontsOPtions =[{
                    output: `${portal_dist}/fonts/fa/`,
                    input: [ './node_modules/font-awesome/fonts/*']
                }, {
                    output: `${portal_dist}/fonts/`,
                    input: [`${portal_src}/fonts/**/*`]
                }];

module.exports = {
    ...DefaultOptions,
    sassOptions :{ ...SassOptions},
    css :{...cssOptions},
    js :{ ...jsOptions },
    ...fontsOPtions
}