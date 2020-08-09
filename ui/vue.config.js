module.exports = {
  configureWebpack: {
    devtool: 'source-map',
  },
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:44307', // target host
        ws: true, // proxy websockets
        changeOrigin: true, // needed for virtual hosted sites
      },
    },
  },
};
