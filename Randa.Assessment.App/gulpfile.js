/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');
var concat = require('gulp-concat');

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


gulp.task("thirdparty", function() {
    gulp.src([
            'core-js/client/**',
            'systemjs/dist/system.src.js',
            'reflect-metadata/**',
            'rxjs/**',
            'zone.js/dist/**',
            '@angular/**',
            'jquery/dist/jquery.*js',
            'bootstrap/dist/js/bootstrap.*js',
            'bootstrap/dist/css/bootstrap.min.css'
    ], {
        cwd: "node_modules/**"
    }).pipe(gulp.dest("./wwwroot/libs"));
});

gulp.task("static", function () {
    gulp.src(["app/Index.html",
              "app/systemjs.config.js",
              "app/app-template.html"])
        .pipe(gulp.dest("./wwwroot/"));

    gulp.src(["app/templates/*.html"])
        .pipe(gulp.dest("./wwwroot/app/templates/"));

    gulp.src(["app/css/*.css"])
        .pipe(gulp.dest("./wwwroot/app/css/"));

    gulp.src(["app/images/"])
        .pipe(gulp.dest("./wwwroot/app/"));

    gulp.src(["app/js/*.js"])
        .pipe(gulp.dest("./wwwroot/app/js/"));
});

gulp.task('typescript', function () {
    var tsProject = ts.createProject('tsconfig.json');
    gulp.src([
        "app/*.ts"
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js
      .pipe(gulp.dest('./wwwroot/app/'));

    tsProject = ts.createProject('tsconfig.json');
    gulp.src([
        "app/references.ts",
        "app/components/*.ts",
        "app/components/**/*.ts"
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js.pipe(gulp.dest('./wwwroot/app/components/'));

});

gulp.task('default', ['typescript', 'static', 'thirdparty']);