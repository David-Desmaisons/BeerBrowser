<template>
  <v-container>
    <v-flex lg12 xs8 offset-xs2 row wrap class="mt-5 mb-5">
      <v-overlay :value="firstload">
        <v-progress-circular indeterminate size="64"></v-progress-circular>
      </v-overlay>

      <v-card class="search">
        <v-form>
          <v-container>
            <v-row>
              <v-col cols="12" md="6">
                <v-text-field v-model="query.name" label="Nome" />
              </v-col>

              <v-col cols="12" md="6">
                <v-text-field v-model="query.ingredient" label="Ingredient" />
              </v-col>

              <v-col cols="12" md="4" class="color-picker">
                <Range v-model="query.color" label="Cor" :min="0" :max="100" />
              </v-col>

              <v-col cols="12" md="4">
                <Range
                  v-model="query.temperature"
                  label="Temperatura"
                  :min="0"
                  :max="30"
                />
              </v-col>

              <v-col cols="12" md="4">
                <Range
                  v-model="query.alcoholPercentage"
                  label="Teor alcoólico"
                  :min="0"
                  :max="100"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-form>
      </v-card>

      <v-card lg12 v-if="nothingFound">
        <v-card-title class="feedback">
          <p>
            Nenhuma cerveja corresponde a essa pesquisa.
          </p>
        </v-card-title>
      </v-card>

      <BeerCard v-for="beer in beers" :key="beer.id" :beer="beer" />
    </v-flex>
  </v-container>
</template>
<script>
import { get } from "../infra/ajax";
import BeerCard from "./BeerCard";
import Range from "./RangeComponent";

import ScrollWatch from "scrollwatch";
const pageLength = 20;

export default {
  name: "BeerFinder",
  components: {
    BeerCard,
    Range
  },
  data() {
    return {
      firstload: true,
      pageNumber: 0,
      loading: false,
      loadedAll: false,
      reloading: false,
      query: {
        name: "",
        ingredient: "",
        color: {
          min: 0,
          max: 100
        },
        temperature: {
          min: 0,
          max: 30
        },
        alcoholPercentage: {
          min: 0,
          max: 100
        }
      },
      beers: []
    };
  },
  async created() {
    await this.loadNextPage();
  },
  mounted() {
    const watch = new ScrollWatch({
      infiniteScroll: true,
      watch: "section",
      infiniteOffset: 200,
      onInfiniteYInView: () => {
        this.loadNextPage();
      }
    });
    this.$once("hook:destroy", () => {
      watch.destroy();
    });
  },
  computed: {
    nothingFound() {
      return !this.firstload && this.beers.length === 0;
    }
  },
  methods: {
    async loadNextPage() {
      const { loadedAll, loading, pageNumber } = this;
      if (loadedAll || loading) {
        return;
      }
      this.loading = true;
      try {
        const query = { pageNumber, pageLength, ...this.query };
        const newBeers = await get("Beers", query);
        this.beers.push(...newBeers.results);
        this.loadedAll = newBeers.done;
        this.pageNumber = pageNumber + 1;
        this.loading = false;
        this.firstload = false;
      } catch (error) {
        window.console.log(error);
      }
    }
  },
  watch:{
    query:{
      deep: true,
      handler(){
        if (this.reloading){
          return;
        }
        this.reloading = true;
        this.$nextTick(async () =>{
          this.firstload = true;
          this.beers = [];
          this.pageNumber =0;
          await this.loadNextPage();
          this.reloading = false;
        });
      }
    }
  }
};
</script>
<style lang="sass" scoped>
.search
  width: 100%

  .color-picker ::v-deep .v-slider.v-slider--horizontal
    background-image: url(../assets/range-product-color.png)
    background-size: 100% 100%
</style>
