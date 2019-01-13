<template>
  <div id="app">
    <edit-insight insight-name="test2"/>
  </div>
</template>

<script>
//import HelloWorld from './components/HelloWorld.vue';
import EditInsight from './components/EditInsight.vue';
import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: 'app',
  components: {
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
