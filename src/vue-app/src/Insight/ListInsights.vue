<template>
    <div class=".popup-visable">
        <ul>
            <li v-for="insight in insights.insights" v-bind:key="insight.id">
               <edit-insight
               :init-insight="insight"
               :init-insight-id="insight.id"
               :init-insight-text="insight.text"
               />
            </li>
        </ul>
    </div>
</template>

<script>
import EditInsight from './EditInsight.vue';

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
  components: { EditInsight },
  data() {
    return {
      insights,
    };
  },
};
</script>

<style>
.popup-visible {
    position: absolute;
    z-index: 10;
    visibility: visible;
}

.popup-hidden {
    position: absolute;
    z-index: 10;
    visibility: hidden;
}
</style>
