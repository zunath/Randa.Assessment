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
    app: 'wwwroot/app/',
    templates: 'wwwroot/app/templates/',
    libs: 'wwwroot/libs/',
    css: 'wwwroot/app/css/',
    js: 'wwwroot/app/js/',
    images: 'wwwroot/app/images/',
    components: 'wwwroot/app/components/'
};

var sourcePaths = {
    app: 'app/',
    css: 'app/css/',
    images: 'app/images/',
    js: 'app/js/',
    services: 'app/services/',
    templates: 'app/templates/',
    index: 'app/Index.html',
    jsconfig: 'app/systemjs.config.js',
    appTemplate: 'app/app-template.html',
    components: 'app/components/'
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
    return gulp.src(["app/images/*"])
        .pipe(gulp.dest(distPaths.images))
        .pipe(connect.reload());
});

gulp.task('templates', function() {
    return gulp.src([sourcePaths.templates + "*.html"])
        .pipe(gulp.dest(distPaths.templates))
        .pipe(connect.reload());
});

gulp.task('css', function() {
    return gulp.src([sourcePaths.css + "*.css"])
        .pipe(gulp.dest(distPaths.css))
        .pipe(connect.reload());
});

gulp.task('js', function() {
    return gulp.src([sourcePaths.js + "*.js"])
        .pipe(gulp.dest(distPaths.js))
        .pipe(connect.reload());
});

gulp.task("root", function () {
    return gulp.src([sourcePaths.index,
              sourcePaths.jsconfig,
              sourcePaths.appTemplate])
        .pipe(gulp.dest(distPaths.root))
        .pipe(connect.reload());
});

gulp.task('typescript', function () {
    var configFile = 'tsconfig.json';
    var tsProject = ts.createProject(configFile);
    gulp.src([
        sourcePaths.app + "*.ts"
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js
      .pipe(gulp.dest(distPaths.app))
      .pipe(connect.reload());

    tsProject = ts.createProject(configFile);
    gulp.src([
        "app/references.ts",
        sourcePaths.components + "*.ts",
        sourcePaths.components + "**/*.ts"
    ]).pipe(ts(tsProject), undefined, ts.reporter.fullReporter())
      .js.pipe(gulp.dest(distPaths.components))
      .pipe(connect.reload());

});

gulp.task('watch', function() {
    connect.server({
        root: distPaths.app,
        port: 1987,
        livereload: true
    });

    gulp.watch([sourcePaths.images + "*"], ['images']);
    gulp.watch([sourcePaths.index, sourcePaths.jsconfig, sourcePaths.appTemplate], ['root']);
    gulp.watch([sourcePaths.templates + "*"], ['templates']);
    gulp.watch([sourcePaths.css + '*'], ['css']);
    gulp.watch([sourcePaths.js + '*'], ['js']);
    gulp.watch([
        sourcePaths.app + '*.ts',
        sourcePaths.components + "*.ts",
        sourcePaths.components + "**/*.ts"], ['typescript']);


});

gulp.task('default',
    [
        'typescript',
        'root',
        'images',
        'js',
        'templates',
        'css',
        'thirdparty'
    ]);