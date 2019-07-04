const gulp = require("gulp"),
    mergeStream = require("merge-stream"),
    concat = require("gulp-concat"),
    header = require('gulp-header'),
    local_conf = require("./Localization.config"),
    pkg = require('../../../package.json'),
    library = require('../library/library.module')
;
      
  
    

     


function po(done){
    let Bundles = library.getBundles(library.regex.po , local_conf.files);
    mergeStream(
        Bundles.map( (file)=> {
        return gulp.src(file.inputs, { base: "."  , allowEmpty: true})
                .pipe(concat(file.output))
                .pipe(header(local_conf.header, { pkg: pkg }))
                .pipe(gulp.dest(local_conf.dist));
    }))
    done();
}



gulp.task(po);