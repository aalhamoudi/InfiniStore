const mix = require('laravel-mix');

mix
   .js('Resources/Logic/App.js', 'Public/js')
   .sass('Resources/Styles/app.scss', 'Public/css');
