<template>
  <div class="home">
    <finder />
  </div>
</template>
<script>
import finder from "../components/BeerFinder"
export default {
  name: "Home",
  props: {
    query: {
      type: Object,
      required: true
    }
  },
  components:{
    finder
  }
};
</script>
