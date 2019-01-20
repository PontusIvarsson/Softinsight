module.exports = {
  devServer: {
    proxy: {
      '/api/*': {
        target: 'https://localhost:44307',
        // target: 'https://localhost:44307',
        changeOrigin: true,
      },
    },
  },
};
