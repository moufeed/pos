var portal_dist = "./wwwroot/portal";
var portal_src = "./src/portal";



module.exports = {
    dist : portal_dist,
    src : portal_src,
    header: '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n',
    sassOptions: {
        outputStyle: 'compressed'
    },
    fonts: [{
        output: `${portal_dist}/fonts/fa/`,
        input: [
            './node_modules/font-awesome/fonts/*',
        ]
    }, {
        output: `${portal_dist}/fonts/`,
        input: [`${portal_src}/fonts/**/*`]
    }],
    css: {
        src: [
            `${portal_src}/scss/**/*.scss`
        ],
        dist: `${portal_dist}/css/`,
        prefixerOptions: {
            browsers: ['last 2 versions', '> 5%', 'Firefox ESR']
        }
    },
    js: {
        dist: `${portal_dist}/js`,
        watch: `${portal_src}/js/**/*.js`,
        files: [
            {
                outputFileName: "script.js",
                es6: true,
                inputFiles: [
                    `${portal_src}/js/scripts.js`
                ]
            },{
                outputFileName: "slider.js",
                es6: false,
                inputFiles: [
                    './node_modules/swiper/dist/js/swiper.min.js',
                    `${portal_src}/js/slider.js`
                ]
            },{
                outputFileName: "validation.js",
                es6: false,
                inputFiles: [
                    './node_modules/jquery-validation/dist/jquery.validate.min.js',
                    './node_modules/jquery-validation/dist/additional-methods.js',
                    `${portal_src}/js/jquery-validation-methods.js`,
                    `${portal_src}/js/jquery-validation-localizatio.js`
                ]
            },{
                outputFileName: "contactus.js",
                es6: true,
                inputFiles: [
                    `${portal_src}/js/Upload.js`,
                    `${portal_src}/js/contactus.js`
                ]
            },{
                outputFileName: "carousel.js",
                es6: false,
                inputFiles: [
                    './node_modules/owl.carousel/dist/owl.carousel.min.js',
                    `${portal_src}/js/carousel.js`
                ]
            },{
                outputFileName: "directory.js",
                es6: true,
                inputFiles: [
                     `${portal_src}/js/directory.js`
                ]
            },{
                outputFileName: "pos.f.js",
                es6: true,
                inputFiles: [
                    `${portal_src}/js/Upload.js`,
                     `${portal_src}/js/pos-form.js`
                ]
            },
            {
                outputFileName: "vendor.f.js",
                es6: true,
                inputFiles: [
                     `${portal_src}/js/vendor-form.js`
                ]
            },
            {
                outputFileName: "vendor.js",
                es6: true,
                inputFiles: [
                     `${portal_src}/js/vendor.js`
                ]
            }
        ]
    },
}