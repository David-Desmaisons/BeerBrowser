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
      <h2>ingredientes</h2>
      <p>{{ allIngredients }}.</p>
    </div>

    <div class="details">
      <div>
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-icon v-bind="attrs" v-on="on">mdi-thermometer</v-icon>
            {{ minTemperature }} - {{ maxTemperature }} ºC
          </template>
          <span>Temperatura ideal</span>
        </v-tooltip>
      </div>

      <div class="alcohol">
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-icon v-bind="attrs" v-on="on">mdi-percent-outline</v-icon>
            {{ alcoholPercentage }}%
          </template>
          <span>Teor alcoólico (% vol)</span>
        </v-tooltip>
      </div>

      <div class="color-picker">
        <v-tooltip bottom>
          <template v-slot:activator="{ on, attrs }">
            <colorDisplayer :value="color" readonly v-bind="attrs" v-on="on" />
          </template>
          <span>Cor</span>
        </v-tooltip>
      </div>
    </div>

    <div class="actions">
      <v-btn
        color="primary"
        fab
        small
        dark
        :to="{ name: 'BeerEdit', params: { id } }"
      >
        <v-icon>mdi-pencil</v-icon>
      </v-btn>
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
    ingredients: {
      type: Array
    },
    ...createProps(String, [
      "name",
      "description",
      "harmonization",
      "pictureUrl"
    ]),
    ...createProps(Number, [
      "id",
      "alcoholPercentage",
      "color",
      "minTemperature",
      "maxTemperature"
    ])
  },
  components: {
    colorDisplayer
  },
  computed: {
    allIngredients() {
      return this.ingredients.reduce(
        (previous, current) => `${previous}, ${current}`
      );
    }
  }
};
</script>
<style lang="sass" scoped>
.beer-detail
  margin-top: 20px
  max-width: 1090px
  display: grid
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
    ::first-letter
      text-transform: capitalize

  .harmonization
    grid-area: harmonization
    margin-right: 20px

  .actions
    grid-area: actions

  .details
    grid-area: details
    display: grid
    grid-template-columns: 1fr 1fr
    grid-template-rows: 1fr 1fr
    grid-template-areas: "name image" "color color"
    text-align: left
    margin-right: 20px

    .color-picker
      grid-area: color

    .alcohol
      text-align: right
</style>
