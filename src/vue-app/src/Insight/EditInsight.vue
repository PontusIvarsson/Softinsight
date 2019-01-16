<template>
  <div>
    <div v-if="editMode" v-on:click="toggleEdit()">
      <div v-html="insight.text">{{insight.id}}</div>
    </div>

    <div v-if="!editMode">
      <textarea v-model="insight.text"></textarea>
      <input type="button" v-on:click="save(insight.text)" value="Save">
    </div>

    <span v-for="hashtag in insight.hashtags" v-bind:key="hashtag">#{{hashtag}}</span>
  </div>
</template>

<script>
export default {
  name: 'EditInsight',
  props: {
    initInsight: null,
  },
  data() {
    return {
      insight: this.initInsight,
      editMode: 'false',
    };
  },
  methods: {
    save(message) {
      console.log(message);
      this.toggleEdit();
    },
    toggleEdit() {
      this.editMode = !this.editMode;
    },
  },
};
</script>

<style>
.color-red {
  color: green;
}
</style>
