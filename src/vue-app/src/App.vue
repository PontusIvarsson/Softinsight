<template>
  <div id="app">
    test1
    <Blog msg="test2"/>
    test3
  </div>
</template>

<script>
//import HelloWorld from './components/HelloWorld.vue';
import Blog from './components/Blog.vue';
import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: 'app',
  components: {
    Blog,
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
