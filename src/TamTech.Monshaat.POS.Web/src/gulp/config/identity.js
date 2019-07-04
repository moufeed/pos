var identity_dist = "./wwwroot/identity";
var identity_src = "./src/identity";

module.exports = {
    dist: identity_dist,
    src: identity_src,
    header: '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n',
    sassOptions: {
        outputStyle: 'compressed'
    },
    css: {
        src: [
            `${identity_src}/scss/**/*.scss`
        ],
        dist: `${identity_dist}/css/`,
        prefixerOptions: {
            browsers: ['last 2 versions', '> 5%', 'Firefox ESR']
        }
    },
    js: {
        dist: `${identity_dist}/js`,
        watch: `${identity_src}/js/**/*.js`,
        files: []
    }
}