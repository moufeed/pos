const identity_dist = "./wwwroot/identity";
const identity_src = "./web-tools/src/identity";



let header = '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n';

module.exports = {
    dist: identity_dist,
    src: identity_src,
    header: header,
    sassOptions: {
        outputStyle: 'compressed'
    },
    css: {
        src: [
            `${identity_src}/scss/**/*.scss`
        ],
        dist: `${identity_dist}/css/`,
    },
    js: {
        dist: `${identity_dist}/js`,
        watch: `${identity_src}/js/**/*.js`,
        files: []
    }
}