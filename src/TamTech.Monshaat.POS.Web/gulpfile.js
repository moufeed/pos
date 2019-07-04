const gulp = require('gulp');
const   requireDir = require('require-dir');
 

 require('require-dir',{ extensions: ['.tasks.js']  })('./web-tools/gulp-tasks/Admin');
 require('require-dir',{ extensions: ['.tasks.js']  })('./web-tools/gulp-tasks/Portal');
 require('require-dir',{ extensions: ['.tasks.js']  })('./web-tools/gulp-tasks/Identity');
 require('require-dir',{ extensions: ['.tasks.js']  })('./web-tools/gulp-tasks/Localization');
