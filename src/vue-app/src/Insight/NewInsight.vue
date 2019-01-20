<template>
  <div>
    <label for="modal-control">+</label>

    <input type="checkbox" id="modal-control" class="modal">
    <div>
      <div class="card">
        <label for="modal-control" class="modal-close"></label>
        <h3 class="section">#NewInsight</h3>
        <textarea v-bind:value="insight.text" ref="insight_text"></textarea>
        <input type="button" class="primary" v-on:click="saveNew()" value="save">
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'NewInsight',
  data() {
    return {
      insight: { text: '' },
    };
  },
  methods: {
    saveNew(text) {
      const a = this.$refs.insight_text.value;
      this.insight.text = a;
      this.$store.commit('addInsight', this.insight);
    },
  },
};
</script>

<style>
</style>
