<template>
  <v-card class="beer-card">
    <img class="picture" alt="foto" :src="beer.pictureUrl" />
    <v-card-text class="name">{{  beer.name }}</v-card-text>
    <v-tooltip bottom="">
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          class="more-info"
          x-small
          icon 
          :to="{ name: 'Info', params: { id: `${beer.id}` } }"
          v-bind="attrs"
          v-on="on"
        >
          <v-icon>mdi-alert-circle-outline</v-icon>
        </v-btn>
      </template>
      <span>Mais informações </span>
    </v-tooltip>
  </v-card>
</template>
<script>
export default {
  name: "BeerCard",
  props: {
    beer: {
      required: true,
      type: Object
    }
  }
};
</script>
<style lang="sass" scoped>
.beer-card
  width: 200px
  height: 300px
  margin: 10px
  display: grid
  grid-template-rows: 1fr 60px
  grid-template-columns: 1fr 60px
  grid-template-areas: "picture picture" "name name"
  justify-items: center

  img.picture
    grid-area: picture
    max-height: 100%
    max-width: 100%
    justify-self: center
    width: auto
    height: auto

  .name
    grid-area: name
    text-align: center
    font-weight: bold

  .more-info
    grid-column: 2
    grid-row: 1
    margin-top: 10px

</style>
