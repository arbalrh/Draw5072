'use strict';

var gulp = require('gulp'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    terser = require('gulp-terser'),
    gulpif = require('gulp-if'),
    strip = require('gulp-strip-comments'),
    gzip = require("gulp-gzip"),
    merge = require('merge-stream'),
    del = require('del'),
    bundleconfig = require('./gulpbundleconfig.json');

const regex = {
    css: /\.css$/,
    js: /\.js$/
};

gulp.task('min:js', async function () {
    merge(getBundles(regex.js).map(bundle => {
        return gulp.src(bundle.inputFiles, { base: '.' })
            .pipe(gulpif(file => !(file.path.includes('.min.js')), terser()))
            .pipe(strip())
            .pipe(concat(bundle.outputFileName))
            //.pipe(gzip())
            .pipe(gulp.dest('.'));
    }))
});

gulp.task('min:css', async function () {
    merge(getBundles(regex.css).map(bundle => {
        return gulp.src(bundle.inputFiles, { base: '.' })
            .pipe(gulpif(file => !(file.path.includes('.min.css')), cssmin()))
            .pipe(concat(bundle.outputFileName))
            //.pipe(gzip())
            .pipe(gulp.dest('.'));
    }))
});

gulp.task('min', gulp.series(['min:js', 'min:css']));

gulp.task('clean', () => {
    return del(bundleconfig.map(bundle => bundle.outputFileName));
});

gulp.task('watch', () => {
    getBundles(regex.js).forEach(
        bundle => gulp.watch(bundle.inputFiles, gulp.series(["min:js"])));

    getBundles(regex.css).forEach(
        bundle => gulp.watch(bundle.inputFiles, gulp.series(["min:css"])));
});

const getBundles = (regexPattern) => {
    return bundleconfig.filter(bundle => {
        return regexPattern.test(bundle.outputFileName);
    });
};

gulp.task('default', gulp.series("min"));