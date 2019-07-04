

function getBundles(regexPattern , files){
    return files.filter(function (bundle) {
        return regexPattern.test(bundle.output);
    });
}

const regex = {
    css: /\.css$/,
    html: /\.(html|htm)$/,
    js: /\.js$/,
    po: /\.po$/
}





exports.getBundles = getBundles;
exports.regex = regex;
