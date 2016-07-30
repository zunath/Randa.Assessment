/// <binding AfterBuild='default' Clean='clean' ProjectOpened='watch' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');
var concat = require('gulp-concat');
var connect = require('gulp-connect');

var distPaths = {
    root: 'wwwroot/',
    libs: 'wwwroot/libs/',
    images: 'wwwroot/images/',
    fonts: 'wwwroot/fonts/'
};

var sourcePaths = {
    app: 'app/',
    images: 'app/images/',
    tsconfig: 'tsconfig.json',
    fonts: 'app/fonts/'
};


gulp.task('clean', function () {
    return gulp.src(
        [
            distPaths.root + "*",
            "!" + distPaths.libs // Intentionally NOT cleaning libs because of how slow they are to pipe to wwwroot.
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
    }).pipe(gulp.dest(distPaths.libs));
});

gulp.task('images', function () {
    return gulp.src([sourcePaths.images + "**/*"])
        .pipe(gulp.dest(distPaths.images))
        .pipe(connect.reload());
});

gulp.task('html', function() {
    return gulp.src([sourcePaths.app + "**/*.html"])
        .pipe(gulp.dest(distPaths.root))
        .pipe(connect.reload());
});

gulp.task('css', function() {
    return gulp.src([sourcePaths.app + "**/*.css"])
        .pipe(gulp.dest(distPaths.root))
        .pipe(connect.reload());
});

gulp.task('js', function() {
    return gulp.src([sourcePaths.app + "**/*.js"])
        .pipe(gulp.dest(distPaths.root))
        .pipe(connect.reload());
});

gulp.task('fonts', function() {
    return gulp.src([sourcePaths.fonts + "**/*"])
        .pipe(gulp.dest(distPaths.fonts))
        .pipe(connect.reload());
});

gulp.task('typescript', function () {
    var tsProject = ts.createProject(sourcePaths.tsconfig);
    gulp.src([
        sourcePaths.app + '**/*.ts'
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js
      .pipe(gulp.dest(distPaths.root))
      .pipe(connect.reload());
});

gulp.task('watch', function() {
    connect.server({
        root: distPaths.root,
        port: 1987,
        livereload: true
    });

    gulp.watch([sourcePaths.images + "**/*"], ['images']);
    gulp.watch([sourcePaths.app + "**/*.html"], ['html']);
    gulp.watch([sourcePaths.app + '**/*.css'], ['css']);
    gulp.watch([sourcePaths.app + '**/*.js'], ['js']);
    gulp.watch([sourcePaths.fonts + '**/*'], ['fonts']);
    gulp.watch([sourcePaths.app + '**/*.ts'], ['typescript']);


});

gulp.task('default',
    [
        'typescript',
        'images',
        'js',
        'fonts',
        'html',
        'css',
        'thirdparty'
    ]);