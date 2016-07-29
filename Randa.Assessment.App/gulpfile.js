/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');
var concat = require('gulp-concat');
var flatten = require('gulp-flatten');

gulp.task('clean', function () {
    return gulp.src(
        [
            // Intentionally NOT cleaning libs because of how slow they are to pipe to wwwroot.
            "./wwwroot/app/",
            "./wwwroot/*.html",
            "./wwwroot/*.js",
            "./wwwroot/templates/"
        ])
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
        .pipe(gulp.dest("./wwwroot/"));

    gulp.src(["components/**/*.template.html"])
        .pipe(gulp.dest("./wwwroot/templates/"));
});

gulp.task('typescript', function (done) {
    var tsProject = ts.createProject('tsconfig.json');
    var tsResult = gulp.src([
        "root/*.ts",
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js
      .pipe(flatten())
      .pipe(gulp.dest('./wwwroot/app/'));

    tsProject = ts.createProject('tsconfig.json');
    var tsResult = gulp.src([
        "root/references.ts",
        "components/**/*.ts",
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js
      .pipe(flatten())
      .pipe(gulp.dest('./wwwroot/app/'));

});

gulp.task('default', ['typescript', 'static', 'thirdparty']);