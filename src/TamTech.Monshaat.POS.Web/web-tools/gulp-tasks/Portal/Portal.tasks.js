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
    portal_config = require('./Portal.config'),
    pkg = require('../../../package.json'),
    library = require('../library/library.module'),
    rimraf = require("rimraf")
;
 

// -------------------------------------------------- Style 
function portaStyle(done){
    gulp.src(portal_config.css.src)
    .pipe(sass(portal_config.sassOptions).on('error', sass.logError))
    .pipe(rename({ suffix: '.min' }))
    .pipe(header(portal_config.header, {  pkg: pkg }))
    .pipe(autoprefixer())
    .pipe(gulp.dest(portal_config.css.dist));
    done();
}

// -------------------------------------------------- Javascript 

function portalJavascript(done){
    let bundles = library.getBundles(library.regex.js,portal_config.js.files);
     
    mergeStream(bundles.map((file)=>{
       let _file;
       if(file.es6){
           
           _file =  gulp.src(file.inputs, { base: "." ,allowEmpty :true})
                   .pipe(concat(file.output))
                   .pipe(babel());                    
       }else{
           _file = gulp.src(file.inputs, { base: ".",allowEmpty :true })
                   .pipe(concat(file.output));
                  
       }
       _file.pipe(uglify({ mangle: false })) 
               .pipe(rename({ suffix: '.min'  }))
               .pipe(header(portal_config.header, { pkg: pkg }))
               .pipe(gulp.dest(portal_config.js.dist));
       return _file;
   }));
   done();
}

// -------------------------------------------------- fonts files 
function portalfonts(done){
    mergeStream(portal_config.fonts.map((folder)=>{
        return gulp.src(folder.input)
        .pipe(gulp.dest(folder.output))
     }))
     done();
}

// -------------------------------------------------- Watch files 
function watchaPortalFiles(){
    gulp.watch(portal_config.js.watch,gulp.series('p:js'));
    gulp.watch(portal_config.css.src, gulp.series('p:css'));
}



gulp.task('p:css', portaStyle );
gulp.task('p:js', portalJavascript );
gulp.task('p:w', watchaPortalFiles);
gulp.task('p',gulp.parallel('p:js','p:css'));