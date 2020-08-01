<template>
  <div class="beer-detail">
    <div>
      {{ Name }}
    </div>
    <div></div>
    <div></div>
  </div>
</template>
<script>
export default {
  props: {
    Name: {
      type: String,
      required: true
    }
  }
};
</script>
<style lang="sass" scoped>
.beer-detail
  display: grid
  grid-template-columns: 1fr 1fr 300px
  grid-template-raws: 1fr
  grid-template-areas: "description image details"
</style>
