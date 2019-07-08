 
const 
    gulp = require('gulp'),
    header = require('gulp-header'),
    watch = require('gulp-watch'),
    sass = require('gulp-sass'),
    concat = require('gulp-concat'),
    rename = require('gulp-rename'),
    autoprefixer = require('gulp-autoprefixer'),
    uglify =  require('gulp-uglify-es').default, 
    mergeStream = require("merge-stream"),
    babel = require('gulp-babel'),
    auth_config = require('./Auth.config'),
    pkg = require('../../../package.json'),
    library = require('../library/library.module')
;

 
// -------------------------------------------------- Style 
function authStyle(done){
        console.log(auth_config.css.dist)
    gulp.src(auth_config.css.src)
        .pipe(sass(auth_config.sassOptions).on('error', sass.logError))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(header(auth_config.header, {
            pkg: pkg
        }))
        .pipe(autoprefixer())
        .pipe(gulp.dest(auth_config.css.dist));
        done();
}

// -------------------------------------------------- Javascript 
function  auth_javscript(done){
    let bundles = library.getBundles(library.regex.js,auth_config.js.files);
     mergeStream(bundles.map((file)=>{
        let _file;
        if(file.es6){
            
            _file =  gulp.src(file.inputs, { base: "." ,allowEmpty :true})
                    .pipe(concat(file.output))
                    .pipe(babel());                    
        }else{
            _file = gulp.src(file.inputs, { base: "." ,allowEmpty :true})
                    .pipe(concat(file.output));
                   
        }

        _file.pipe(uglify({ mangle: false })) 
                .pipe(rename({ suffix: '.min'  }))
                .pipe(header(auth_config.header, { pkg: pkg }))
                .pipe(gulp.dest(auth_config.js.dist));
        return _file;
    }));
    done();
}





// -------------------------------------------------- Watch files 
function watchaauthFiles(){
    gulp.watch(auth_config.js.watch, gulp.series('at:js'));
    gulp.watch(auth_config.css.src, gulp.series('at:css'));
}




gulp.task('at:w', watchaauthFiles);
gulp.task("at:js",auth_javscript);
gulp.task('at:css',authStyle);
gulp.task('at',gulp.parallel('at:js','at:css'));