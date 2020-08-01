<template>
  <v-card class="beer-detail">
    <div class="name">
      {{ name }}
    </div>
    <div class="description">
      {{ description }}
    </div>
    <div class="harmonization">
      <h2>Harmonização</h2>
      {{ harmonization }}
    </div>
    <div class="ingredients">
      <h2>Ingredients</h2>
      {{ ingredients }}
    </div>

    <div>
      <h2>Temperatura ideal</h2>
      {{ temperature }}
      <h2>Teor alcoólico</h2>
      {{ alcoholPercentage }}%
      <h2>Cor</h2>
      {{ color }}%
    </div>

    <img class="image" :src="pictureUrl" alt="foto" />
    <div></div>
    <div></div>
  </v-card>
</template>
<script>
const createProps = (type, names) =>
  names
    .map(name => ({ [name]: { type } }))
    .reduce((previous, current) => ({ ...previous, ...current }), {});

export default {
  props: {
    ...createProps(String, [
      "name",
      "description",
      "harmonization",
      "ingredients",
      "temperature",
      "pictureUrl"
    ]),
    ...createProps(Number, ["id", "alcoholPercentage", "color"])
  }
};
</script>
<style lang="sass" scoped>
.beer-detail
  margin: 20px
  display: grid
  max-width: 1090px
  grid-template-columns: minmax(auto, 1fr) 2fr 300px
  grid-template-rows: 120px 320px 60px
  grid-template-areas: "name image harmonization" "description image details" "ingredients image actions"
  column-gap: 10px
  row-gap: 10px
  padding: 10px

  *
    justify-self: stretch !important

  .image
    grid-area: image
    max-height: 100%
    justify-self: center

  .name
    grid-area: name
    font-size: 71px
    font-weight: bold

  .description
    grid-area: description

  .ingredients
    grid-area: ingredients
</style>