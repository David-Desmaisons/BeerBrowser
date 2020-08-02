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

    <div class="details">
      <h2>Temperatura ideal</h2>
      {{ minTemperature }} - {{maxTemperature}} ºC
      <h2>Teor alcoólico</h2>
      {{ alcoholPercentage }} % vol
      <h2>Cor</h2>
      <colorDisplayer class="color-picker" :value="color" readonly/>
    </div>

    <img class="image" :src="pictureUrl" alt="foto" />
  </v-card>
</template>
<script>
import colorDisplayer from "./ColorDisplayer";
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
      "pictureUrl"
    ]),
    ...createProps(Number, ["id", "alcoholPercentage", "color", "minTemperature", "maxTemperature"])
  },
  components:{
    colorDisplayer
  }
};
</script>
<style lang="sass" scoped>
.beer-detail
  margin-top: 20px
  display: grid
  max-width: 1090px
  grid-template-columns: minmax(auto, 1fr) 2fr 300px
  grid-template-rows: 120px 320px 60px
  grid-template-areas: "name image harmonization" "description image details" "ingredients image actions"
  column-gap: 10px
  row-gap: 10px
  padding: 10px 10px 10px 10px

  @media screen and (max-width: 1100px)
    grid-template-columns: 1fr 1fr
    grid-template-rows: 120px 140px 100px 100px auto 60px
    grid-template-areas: "name image" "description image" "harmonization image" "ingredients image" "details image" "details actions"

  *
    justify-self: stretch !important
    align-self: center

  .image
    grid-area: image
    max-height: 100%
    justify-self: center
    width: auto
    height: auto

  .name
    grid-area: name
    font-size: 71px
    font-weight: bold

  .description
    grid-area: description

  .ingredients
    grid-area: ingredients

  .harmonization
    grid-area: harmonization

  .details
    grid-area: details
    .color-picker
      margin-right: 10px
</style>
