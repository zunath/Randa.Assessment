/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');
var concat = require('gulp-concat');

// Delete the dist directory
gulp.task('clean', function () {
    return gulp.src("./wwwroot/*")
        .pipe(clean());
});


gulp.task("thirdparty", function(done) {
    gulp.src([
            'core-js/client/**',
            'systemjs/dist/system.src.js',
            'reflect-metadata/**',
            'rxjs/**',
            'zone.js/dist/**',
            '@angular/**',
            'jquery/dist/jquery.*js',
            'bootstrap/dist/js/bootstrap.*js',
    ], {
        cwd: "node_modules/**"
    }).pipe(gulp.dest("./wwwroot/libs"));
});

gulp.task("static", function (done) {
    gulp.src(["root/Index.html",
              "root/systemjs.config.js",
              "root/app.template.html"])
        .pipe(gulp.dest("./wwwroot/"))
});

var rootProject = ts.createProject('tsconfig.json');
gulp.task('root', function (done) {
    var tsResult = gulp.src([
        "root/*.ts"
    ]).pipe(ts(rootProject), undefined, ts.reporter.fullReporter());

    return tsResult.js.pipe(gulp.dest('./wwwroot/app/'));

});


var tsProject = ts.createProject('tsconfig.json');
gulp.task('typescript', function (done) {
    var tsResult = gulp.src([
            "components/footer/footer.component.ts",
            //"services/**/*.ts"
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter());

    return tsResult.js
        //.pipe(concat("compiled.js"))
        .pipe(gulp.dest('./wwwroot/app/'));
});


gulp.task('default', ['root', 'typescript', 'static', 'thirdparty']);