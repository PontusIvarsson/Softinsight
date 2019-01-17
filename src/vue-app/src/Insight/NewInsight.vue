<template>
  <div>

    <label for="modal-control">Show modal</label>

    <input type="checkbox" id="modal-control" class="modal">
    <div>
      <div class="card">
        <label for="modal-control" class="modal-close"></label>
        <h3 class="section">Modal</h3>
        <p class="section">This is a modal dialog!</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'NewInsight',
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
</style>
