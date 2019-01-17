<template>
  <div>
    <h3 class="section double-padded">
      <span v-for="hashtag of insight.hashtags" v-bind:key="hashtag">#{{hashtag}}</span>
    </h3>

    <div class="section double-padded">
      <div v-if="editMode" v-html="insight.text" v-on:click="toggleEdit()"></div>
      <div v-if="!editMode">
        <textarea v-bind:value="insight.text" ref="insight_text"></textarea>
        <br>
        <input type="button" v-on:click="cancel(insight.id)" value="Cancel">
        <input
          type="button"
          v-on:click="save(insight.id, $event.target.value)"
          class="primary"
          value="Save"
        >
      </div>
    </div>
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
    save() {
      const text = this.$refs.insight_text.value;
      this.insight.text = text;

      this.toggleEdit();
    },
    cancel() {
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
