import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';

Vue.use(Vuex);

export default new Vuex.Store({

  state: {
    insights: [
      { id: 1, text: 'test 1' },
      { id: 2, text: 'test 2', hashtags: ['test 2', 'tag2', 'tag3'] },
      { id: 3, text: 'test 3', hashtags: ['test 3', 'tag2', 'tag3'] },
      { id: 4, text: 'test 4', hashtags: ['test 4', 'tag2', 'tag3'] },
      { id: 5, text: 'test 5', hashtags: ['test 5', 'tag2', 'tag3'] },
    ],
    blog: null,
  },
  actions: {
    getBlogs({ commit }) {
      axios.get('/api/blog')
        .then(result => commit('updateBlog', result.data))
        .catch(console.error);
    },
  },
  mutations: {
    addInsight(state, insight) {
      state.insights.push({ id: 10, text: insight.text, hashtags: ['verynew'] });
    },
    updateBlog(state, blogs) {
      state.blogs = blogs;
    },
  },
});
