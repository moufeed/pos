 
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
    admin_config = require('./Admin.config'),
    pkg = require('../../../package.json'),
    library = require('../library/library.module')
;

 
// -------------------------------------------------- Style 
function AdminStyle(done){
    gulp.src(admin_config.css.src)
        .pipe(sass(admin_config.sassOptions).on('error', sass.logError))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(header(admin_config.header, {
            pkg: pkg
        }))
        .pipe(autoprefixer())
        .pipe(gulp.dest(admin_config.css.dist));
        done();
}

// -------------------------------------------------- Javascript 
function  Admin_javscript(done){
    let bundles = library.getBundles(library.regex.js,admin_config.js.files);
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
                .pipe(header(admin_config.header, { pkg: pkg }))
                .pipe(gulp.dest(admin_config.js.dist));
        return _file;
    }));
    done();
}





// -------------------------------------------------- Watch files 
function watchaAdminFiles(){
    gulp.watch(admin_config.js.watch, gulp.series('a:js'));
    gulp.watch(admin_config.css.src, gulp.series('a:css'));
}




gulp.task('a:w', watchaAdminFiles);
gulp.task("a:js",Admin_javscript);
gulp.task('a:css',AdminStyle);
gulp.task('a',gulp.parallel('a:js','a:css'));