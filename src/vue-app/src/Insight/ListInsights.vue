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
          v-for="insight in insights.insights"
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

const insights = {
  insights: [
    { id: 1, text: 'test 1', hashtags: ['test 1', 'tag2', 'tag3'] },
    { id: 2, text: 'test 2', hashtags: ['test 2', 'tag2', 'tag3'] },
    { id: 3, text: 'test 3', hashtags: ['test 3', 'tag2', 'tag3'] },
    { id: 4, text: 'test 4', hashtags: ['test 4', 'tag2', 'tag3'] },
    { id: 5, text: 'test 5', hashtags: ['test 5', 'tag2', 'tag3'] },
  ],
};

export default {
  components: { NewInsight, EditInsight },
  data() {
    return {
      insights,
    };
  },
};
</script>

<style>
.minheight {
  min-height: 500px;
}
</style>
