<template>

  <div>
  <h1>{{insightName}}</h1>

  <input type="checkbox" v-model="editMode">

  <div v-if="editMode">
    <div v-html="content" v-bind:class="'color-' + color"> </div>
  </div>

  <div v-if="!editMode">
    <textarea v-model="content"></textarea>
    <input type="button" v-on:click="al(content)" value="Save"/>
  </div>


  <ul>
      <li v-for="hashtag in hashtags" v-bind:key="hashtag">
        <span v-bind:text="content"></span>
        {{hashtag}}
      </li>
  </ul>

    View output:<br>
    {{content}}
  </div>

</template>

<script>
export default {
  name: 'EditInsight',
  props: {
    insightName: String,
  },
  data() {
    return {
      color: 'red',
      editMode: 'true',
      content: 'wow det här är content',
      hashtags: ['#tag1', '#tag2', '#tag3'],
    };
  },
  methods: {
    al(message) {
      console.log(message);
      this.content = `${message}a`;
      this.hashtags.push('#newtag');
    },
  },
};
</script>

<style>
  .color-red {
    color: green;
  }
</style>
