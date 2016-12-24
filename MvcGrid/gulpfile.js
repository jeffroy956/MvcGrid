/// <binding ProjectOpened='watch' />

var gulp = require("gulp"),
    gulpWatch = require("gulp-watch"),
    less = require("gulp-less"),
    sourcemaps = require("gulp-sourcemaps");

gulp.task("less", function () {
    return gulp.src("./Content/website.less")
        .pipe(sourcemaps.init())
        .pipe(less())
        .pipe(sourcemaps.write("../Content"))
        .pipe(gulp.dest("./Content"));
});

gulp.task("watch", function () {
    gulpWatch(["./Content/*.less"], function () { gulp.start("less") });
});