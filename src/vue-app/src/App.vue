<template>
  <div id="app">
    <list-insights/>
    <list-blog/>
  </div>
</template>

<script>
import ListInsights from './Insight/ListInsights.vue';
import ListBlog from './Insight/ListBlog.vue';


export default {
  name: 'app',
  components: {
    ListInsights,
    ListBlog,
  },
};
</script>

<style lang="scss">
@import '../public/minsrc/flavors/mini-default.scss';
</style>
