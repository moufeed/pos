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
    iconf = require('./Identity.config'),
    pkg = require('../../../package.json'),
    library = require('../library/library.module'),
    rimraf = require("rimraf")
;




// -------------------------------------------------- Style 
function IdentityStyle(done){
    gulp.src(iconf.css.src)
        .pipe(sass(iconf.sassOptions).on('error', sass.logError))
        .pipe(rename({ suffix: '.min' }))
        .pipe(header(iconf.header, { pkg: pkg }))
        .pipe(autoprefixer())
        .pipe(gulp.dest(iconf.css.dist));

        done();
}


// -------------------------------------------------- JavaScript 


function IdentityJavscript(done){
    let bundles = library.getBundles(library.regex.js,iconf.js.files);
    mergeStream(bundles.map((file)=>{
       let _file;
       if(file.es6){
           
           _file =  gulp.src(file.inputs, { base: "." })
                   .pipe(concat(file.output))
                   .pipe(babel());                    
       }else{
           _file = gulp.src(file.inputs, { base: "." })
                   .pipe(concat(file.output));
                  
       }

       _file.pipe(uglify({ mangle: false })) 
               .pipe(rename({ suffix: '.min'  }))
               .pipe(header(iconf.header, { pkg: pkg }))
               .pipe(gulp.dest(iconf.js.dist));
       return _file;
   }));
   done();
    
}
 



// ---------------------------------------------------- fonts
 
function portalfonts(done){
    mergeStream(iconf.fonts.map((folder)=>{
        return gulp.src(folder.input)
        .pipe(gulp.dest(folder.output))
     }))
     done();
}



 // -------------------------------------------------- Watch files 
function watchaPortalFiles(done){
    gulp.watch(iconf.js.watch,gulp.series('i:js'));
    gulp.watch(iconf.css.src, gulp.series('i:css'));
    done();
}

 
 

gulp.task('i:css', IdentityStyle);
gulp.task('i:js', IdentityJavscript );
gulp.task('i:f', portalfonts );
gulp.task('i:w',  watchaPortalFiles );

gulp.task('i',gulp.parallel('i:js','i:css'));