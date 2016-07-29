/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');
var destPath = './wwwroot/libs/';

var paths = {
    scripts: ['scripts/*.ts',
              'scripts/*.js',
              'scripts/**/*.js',
              'scripts/**/*.ts',
              'scripts/**/*.map']
};

// Delete the dist directory
gulp.task('clean', function () {
    return gulp.src(destPath)
        .pipe(clean());
});


gulp.task("scripts", () => {
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
        cwd: "libs/**"
    })
        .pipe(gulp.dest("./wwwroot/libs"));

    gulp.src(["Index.html", "systemjs.config.js"])
        .pipe(gulp.dest("./wwwroot/"))
});


var tsProject = ts.createProject('tsconfig.json');
gulp.task('ts', function (done) {
    var tsResult = gulp.src([
            "scripts/*.ts"
    ])
        .pipe(ts(tsProject), undefined, ts.reporter.fullReporter());
    return tsResult.js.pipe(gulp.dest('./wwwroot/app'));
});

gulp.task('watch', function () {
    return gulp.watch(config.src, ['scripts']);
});

gulp.task('default', ['ts', 'scripts']);