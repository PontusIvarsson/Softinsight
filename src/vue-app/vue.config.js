module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:44307/api/blog/',
        changeOrigin: true,
      },
    },
  },
};
