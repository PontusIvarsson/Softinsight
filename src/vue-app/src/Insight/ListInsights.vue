<template>
  <div>


    <div class="input-group">
      <input id="search" type="text" placeholder="looking for something..">
    </div>


    <div class="row cols-sm-12 cols-lg-10 minheight">
      <!-- Add the extra style to make card spacing look better -->
      <div
        class="col-lg-offset-1 row"
        style="-webkit-justify-content: space-around; justify-content: space-around;"
      >
        <new-insight/>

        <edit-insight
          v-for="insight in getSearchInsightResult"
          v-bind:key="insight.id"
          :init-insight="insight"
          class="card"
        />
      </div>
    </div>
  </div>
</template>

<script>
import EditInsight from './EditInsight.vue';
import NewInsight from './NewInsight.vue';


export default {
  components: { NewInsight, EditInsight },
  computed: {
    getSearchInsightResult() {
      return this.$store.state.insights;
    },
  },
};
</script>

<style>
.minheight {
  min-height: 500px;
}
</style>
