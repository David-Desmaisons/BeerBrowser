<template>
  <div>
    <v-flex
      lg10
      offset-lg1
      xs8
      offset-xs2
      row
      wrap
      class="mt-5 mb-5 movie-item-container"
    >
      <v-overlay :value="firstload">
        <v-progress-circular indeterminate size="64"></v-progress-circular>
      </v-overlay>

      <v-card lg12 v-if="nothingFound">
        <v-card-title class="feedback">
          <p>
            Nenhuma cerveja corresponde a essa pesquisa.
          </p>
        </v-card-title>
      </v-card>

      <BeerCard v-for="beer in beers" :key="beer.id" :beer="beer" />
    </v-flex>

    <v-tooltip top>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="primary"
          fab
          small
          dark
          :to="{ name: 'Create' }"
          v-bind="attrs"
          v-on="on"
        >
          <v-icon>mdi-plus</v-icon>
        </v-btn>
      </template>
      <span>Adicionar nova cerveja</span>
    </v-tooltip>
  </div>
</template>
<script>
import { get } from "../infra/ajax";
import BeerCard from "./BeerCard";


export default {
  name: "BeerFinder",
  components:{
    BeerCard
  },
  data() {
    return {
      firstload: true,
      beers: []
    };
  },
  async created() {
    const allBeers = await get("Beers");
    this.beers = allBeers.results;
    this.firstload = false;
  },
  computed: {
    nothingFound() {
      return !this.firstload && this.beers.length === 0;
    }
  }
};
</script>
