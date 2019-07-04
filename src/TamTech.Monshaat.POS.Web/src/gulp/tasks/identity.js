const 
gulp = require('gulp'),
header = require('gulp-header'),
watch = require('gulp-watch'),
sass = require('gulp-sass')
concat = require('gulp-concat'),
rename = require('gulp-rename'),
autoprefixer = require('gulp-autoprefixer'),
uglify =  require('gulp-uglify-es').default, 
merge = require("merge-stream"),
babel = require('gulp-babel'),
iconf = require('../config/identity'),
pkg = require('../../../package.json'),
mod = require('../lib/module'),
rimraf = require("rimraf")
;
 


//-------------------------------------------------
// --  identity style files 
//-------------------------------------------------

gulp.task("i:clean_js", done => rimraf(iconf.js.dist, done));

gulp.task("i:clean_css", done => rimraf(iconf.css.dist, done));

gulp.task("i:clean", ["i:clean_css", "i:clean_js"]);

gulp.task('i:css', ()=> {
    console.log
    return gulp.src(iconf.css.src)
        .pipe(sass(iconf.sassOptions).on('error', sass.logError))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(header(iconf.header, {
            pkg: pkg
        }))
        .pipe(autoprefixer(iconf.css.prefixerOptions))
        .pipe(gulp.dest(iconf.css.dist));
});



// ----------------------------------------------------
// -- portal javscript files
// ----------------------------------------------------

gulp.task("i:js",  ()=> {
    let tasks = mod.getBundles(mod.regex.js , iconf.js.files).map( (file)=> {
        let  g = gulp.src(file.inputFiles, { base: "." })
                .pipe(concat(file.outputFileName));
                if(file.es6){
                    g.pipe(babel({
                        presets: ['@babel/env']
                    }))
                } 
                g.pipe(uglify({
                    mangle: true
                }))
                .pipe(rename({
                    suffix: '.min'
                }))
                .pipe(header(iconf.header, {
                    pkg: pkg
                }))
                .pipe(gulp.dest(iconf.js.dist));
            return g;
    });
    return merge(tasks);
});



// ----------------------------------------------------
// -- portal fonts files
// ----------------------------------------------------

gulp.task('i:f', function() {

    let tasks = iconf.fonts.map((folder)=>{
       return gulp.src(folder.input)
       .pipe(gulp.dest(folder.output))
    })
    
    return merge(tasks)
 })
 

// ----------------------------------------------------
// -- portal  watch files
// ----------------------------------------------------

gulp.task('i:w',  ()=> {
    gulp.watch(iconf.js.watch, ['i:js']);
    gulp.watch(iconf.css.src, ['i:css']);
});
