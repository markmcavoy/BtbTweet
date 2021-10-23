const path = require('path');

module.exports = {
  entry: {
    btbtweet: './React/index.js',
  },

  mode: 'development',
  devtool: 'inline-source-map',
  performance: {
    maxEntrypointSize: 5120000,
    maxAssetSize: 5120000,
  },
  output: {
    path: __dirname + '/dist/js',
    filename: '[name].js',
  },
  module: {
    rules: [
      {
        test: /\.js|\.jsx$/,
        exclude: /(node_modules)/,
        use: {
          loader: 'babel-loader',
        },
      },
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader'],
      },
      {
        test: /\.(png|jpe?g|gif)$/i,
        use: [
          {
            loader: 'file-loader',
          },
        ],
      },
      {
        test: /\.svg/,
        use: {
          loader: 'svg-url-loader',
          options: {
            // make all svg images to work in IE
            iesafe: true,
          },
        },
      },
    ],
  },
  externals: {
    // require("jquery") is external and available
    //  on the global var jQuery
    jquery: 'jQuery',
  },
};
