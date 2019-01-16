<template>
  <div id="app">

    <list-insights/> <!---
    <edit-insight insight-name="test2"/>
   <hello-world insight-name="test2"/>-->

  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue';
import ListInsights from './Insight/ListInsights.vue';
import EditInsight from './Insight/EditInsight.vue';
import HelloWorld from './components/HelloWorld.vue';

export default {
  name: 'app',
  components: {
    ListInsights,
    EditInsight,
    HelloWorld,
  },
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
