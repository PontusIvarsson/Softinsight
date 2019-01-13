<template>
<div>
  <h1>{{insightName}}</h1>
  <textarea :value="content"></textarea>
  <input type="button" v-on:click="al('hoho')" value="Save"/>

  <hr>
  View output:<br>
  <div v-bind:text="content"></div>
  <span :value="content"/>
  <input :value="content" />
</div>
</template>

<script>
export default{
  name: 'EditInsight',
  props: {
    insightName: String,
  },
  data() {
    return{
    content: "wow det här är content asdf"
    }
  },
  methods: {
    al(message){
      console.log("test");
      alert(message);
    },
  },
}
</script>

<style>
</style>