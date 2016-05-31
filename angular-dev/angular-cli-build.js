/* global require, module */

var Angular2App = require('angular-cli/lib/broccoli/angular2-app');

module.exports = function (defaults) {
  return new Angular2App(defaults, {
    vendorNpmFiles: [
      'systemjs/dist/system-polyfills.js',
      'systemjs/dist/system-polyfills.map',
      'systemjs/dist/system.src.js',
      'systemjs/dist/system.src.map',
      'zone.js/dist/*.js',
      'zone.js/dist/*.map',
      'es6-shim/es6-shim.js',
      'es6-shim/es6-shim.map',
      'reflect-metadata/*.js',
      'reflect-metadata/*.map',
      'rxjs/**/*.js',
      'rxjs/**/*.map',
      '@angular/**/*.js',
      '@angular/**/*.map'
    ]
  });
};
