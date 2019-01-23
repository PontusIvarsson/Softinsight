<template>
<div v-if="blogs">
    <span v-for="blog in blogs" v-bind:key="blog.blogId">{{blog.blogName}} {{blog.hashtag}}</span>
</div>
</template>

<script>


export default {
  created() {
    this.$store.dispatch('getBlogs');
  },
  computed: {
    blogs() {
      return this.$store.state.blog;
    },
  },
};
</script>

<style>
</style>
