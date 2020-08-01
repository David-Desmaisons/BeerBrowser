<template>
  <div class="beer-detail">
    <div class="name">
      {{ name }}
    </div>
    <img :src="pictureUrl" alt="foto" />
    <div></div>
    <div></div>
  </div>
</template>
<script>
export default {
  props: {}
};
</script>
<style lang="sass" scoped>
.beer-detail
  display: grid
  grid-template-columns: 1fr 1fr 300px
  grid-template-rows: 120px 1fr
  grid-template-areas: "name image harmonization" "description image details"

  .image
    grid-area: image

  .name
    grid-area: name
    font-size: 71px
    font-weight: bold
</style>
