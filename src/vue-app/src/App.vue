<template>
  <div id="app">
    <list-insights/>
  </div>
</template>

<script>
import ListInsights from './Insight/ListInsights.vue';


export default {
  name: 'app',
  components: {
    ListInsights,
  },
};
</script>

<style lang="scss">
@import '../public/minsrc/flavors/mini-default.scss';
</style>
