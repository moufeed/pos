var gulp = require('gulp'),
    header = require('gulp-header'),
    pkg = require('./package.json'),
    watch = require('gulp-watch'),
    sass = require('gulp-sass')
    concat = require('gulp-concat'),
    rename = require('gulp-rename'),
    handlebars = require('gulp-compile-handlebars'),
    sourcemaps = require('gulp-sourcemaps'),
    autoprefixer = require('gulp-autoprefixer'),
    uglify = require('gulp-uglify');


var config = {

    header: '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n',
    sassOptions :{
        outputStyle: 'compressed'
    },
    css: {
        src: ['./src/scss/**/*.scss'],
        dist: "./dist/assets/css",
        map: "./maps",
        prefixerOptions : {
            browsers: ['last 2 versions', '> 5%', 'Firefox ESR']
        }
    },
    js: {
        src: [
            './node_modules/jquery/dist/jquery.min.js',
            './node_modules/bootstrap/dist/js/bootstrap.min.js',
            './node_modules/lightbox2/dist/js/lightbox.min.js',
            './src/js/scripts.js'
        ],
        dist: "./dist/assets/js",
        file: "script.js"
    },

    html: {
        src: 'src/templates/*.hbs',
        watch : ['src/templates/**/*.hbs','./src/json/*.json'],
        ltrData: require('./src/json/en.json'),
        rtlData: require('./src/json/ar.json'),
        options: {
            ignorePartials: true,
            batch: ['./src/templates/partials'],
            helpers :{
                capitals: function (str) {
                    return str.toUpperCase();
                }
            }
        }
    },
    images :{
        src : "./src/images/*",
        dist : "./dist/assets/images/"
    }
}

 

// ----------------------------------------------------
// -------------   handlebars/html  -------------------
// ----------------------------------------------------
gulp.task('hbs:ltr', function () {
     
    return gulp.src(config.html.src)
        .pipe(handlebars(config.html.ltrData, config.html.options))
        .pipe(rename({
            extname: '.html'
        }))
        .pipe(gulp.dest('dist'));
});

gulp.task('hbs:rtl', function () {
     
    return gulp.src(config.html.src)
        .pipe(handlebars(config.html.rtlData, config.html.options))
        .pipe(rename({
            suffix: '-ar',
            extname: '.html'
        }))
        .pipe(gulp.dest('dist'));
});


// ----------------------------------------------------
// -----------------   sass/css  ----------------------
// ----------------------------------------------------

gulp.task('style', function () {
    return gulp.src(config.css.src)
        //.pipe(sourcemaps.init())
        .pipe(sass(config.sassOptions).on('error', sass.logError))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(header(config.header, {
            pkg: pkg
        }))
        .pipe(autoprefixer(config.css.prefixerOptions))
        //.pipe(sourcemaps.write(config.css.map))
        .pipe(gulp.dest(config.css.dist));
})


// ----------------------------------------------------
// -----------------   javascript/js  -----------------
// ----------------------------------------------------
gulp.task('script', function () {
    return gulp.src(config.js.src)
        .pipe(concat(config.js.file))
        .pipe(uglify({
            mangle: true
        }))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(header(config.header, {
            pkg: pkg
        }))
        .pipe(gulp.dest(config.js.dist));
})

// ----------------------------------------------------
// -----------------   Images/copy  -----------------
// ----------------------------------------------------

gulp.task('copy:img', function () {
    return gulp.src(config.images.src)
        .pipe(gulp.dest(config.images.dist));
})


// ----------------------------------------------------
// -----------------   watch/files  -----------------
// ----------------------------------------------------
gulp.task('watch', function () {
    gulp.watch(config.js.src, ['script']);
    gulp.watch(config.css.src, ['style']);
    gulp.watch(config.html.watch,['hbs'] );
    gulp.watch(config.images.src,['copy:img'] );
})


gulp.task('hbs', ['hbs:ltr', 'hbs:rtl']);

gulp.task('default', ['script', 'style','hbs','watch']);



handlebars.Handlebars.registerHelper('MakeList', function (obj, options) {

    var result = '';

    if(obj.subLinks){

        result += `<li  class="has_submenu">
            <a href="#collapse-${obj.id}" class=""  data-toggle="collapse"   role="button" aria-expanded="false" aria-controls="collapse-${obj.id}">
               ${obj.Link} 
              <i class="fas fa-chevron-left"></i>
             </a> <div class="collapse" id="collapse-${obj.id}"> <ul>`;
        obj.content.forEach(element => {
            if(element.published && element.add_to_submenu){
                result += `
                       <li> 
                         <a href="#${element.id}" class="">${element.title}</a>  
                       </li>
               `;
            }
        });
        result += ` </ul></div></li>`;
    }else{
        result += `<li> <a href="#${obj.id}"> ${obj.Link}</a> </li>`;
    }
   
    return result;
})

handlebars.Handlebars.registerHelper('MakeNav', function (obj, options) {

    var result = '';

    if(obj.subLinks){
        result += `<span><a class="nav-link" href="#${obj.id}"> <i class="fas fa-chevron-left"></i> ${obj.Link} </a>`;
        result += ` <nav class="nav subnav flex-column">`;
        
             
        obj.content.forEach(element => {
            if(element.published && element.add_to_submenu){
                result += `<a class="nav-link" href="#${element.id}">${element.title}</a> `;
            }
        });
        result += ` </nav></span>`;
    }else{
        result += `<span><a class="nav-link" href="#${obj.id}">${obj.Link} </a></span>`;
    }
   
    return result;
})

 
   
handlebars.Handlebars.registerHelper('isequal', function (v1, v2, options) {
    if (v1 === v2) {
        return options.fn(this);
    }
    return options.inverse(this)
})

handlebars.Handlebars.registerHelper('times', function (n, block) {
    var accum = '';
    for (var i = 0; i < n; ++i)
        accum += block.fn(i);
    return accum;
});
handlebars.Handlebars.registerHelper('for', function (from, to, incr, block) {
    var accum = '';
    for (var i = from; i < to; i += incr)
        accum += block.fn(i);
    return accum;
});

handlebars.Handlebars.registerHelper('each_upto', function (ary, max, options) {
    if (!ary || ary.length == 0)
        return options.inverse(this);

    var result = [];
    for (var i = 0; i < max && i < ary.length; ++i)
        result.push(options.fn(ary[i]));
    return result.join('');
});

handlebars.Handlebars.registerHelper('each_fromto', function (ary, from, max, options) {
    if (!ary || ary.length == 0)
        return options.inverse(this);

    var result = [];
    for (var i = from; i < max + from && i < ary.length; ++i)
        result.push(options.fn(ary[i]));
    return result.join('');
});




handlebars.Handlebars.__switch_stack__ = [];

handlebars.Handlebars.registerHelper( "switch", function( value, options ) {
    handlebars.Handlebars.__switch_stack__.push({
        switch_match : false,
        switch_value : value
    });
    var html = options.fn( this );
    handlebars.Handlebars.__switch_stack__.pop();
    return html;
} );
handlebars.Handlebars.registerHelper( "case", function( value, options ) {
    var args = Array.from( arguments );
    var options = args.pop();
    var caseValues = args;
    var stack = handlebars.Handlebars.__switch_stack__[handlebars.Handlebars.__switch_stack__.length - 1];
    
    if ( stack.switch_match || caseValues.indexOf( stack.switch_value ) === -1 ) {
        return '';
    } else {
        stack.switch_match = true;
        return options.fn( this );
    }
} );
handlebars.Handlebars.registerHelper( "default", function( options ) {
    var stack = handlebars.Handlebars.__switch_stack__[handlebars.Handlebars.__switch_stack__.length - 1];
    if ( !stack.switch_match ) {
        return options.fn( this );
    }
} );

handlebars.Handlebars.registerHelper( "even", function( number, options ) {
    if((number % 2) == 0) {
        return options.fn(this);
      } else {
        return options.inverse(this);
    }
})

handlebars.Handlebars.registerHelper( "odd", function( number, options ) {
    if((number % 2) != 0) {
        return options.fn(this);
      } else {
        return options.inverse(this);
    }
})

handlebars.Handlebars.registerHelper('ifObject', function (item, options) {
    
    console.log(item)
    if(typeof item === "object") {
        return options.fn(this);
      } else {
        return options.inverse(this);
      }
});