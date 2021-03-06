<template>
  <v-container class="container">
    <v-flex lg12 xs8 offset-xs2 row wrap class="mt-5 mb-5 main-container">
      <v-overlay :value="firstload">
        <v-progress-circular indeterminate size="64"></v-progress-circular>
      </v-overlay>

      <v-card class="search">
        <v-form>
          <v-container>
            <v-row>
              <v-col cols="12" md="6">
                <v-text-field
                  v-model="query.name"
                  label="Nome"
                  placeholder="Digita aqui"
                />
              </v-col>

              <v-col cols="12" md="6">
                <Autocomplete
                  v-model="query.ingredient"
                  label="Ingrediente"
                  url="ingredients"
                  placeholder="Digita aqui"
                />
              </v-col>

              <v-col cols="12" md="4" class="color-picker">
                <Range
                  v-model="query.color"
                  label="Cor"
                  :min="0"
                  :max="100"
                  :thumb-label="false"
                />
              </v-col>

              <v-col cols="12" md="4">
                <Range
                  v-model="query.temperature"
                  label="Temperatura ideal"
                  thumb-label="always"
                  unity="ºC"
                  :min="0"
                  :max="30"
                />
              </v-col>

              <v-col cols="12" md="4">
                <Range
                  v-model="query.alcoholPercentage"
                  label="Teor alcoólico"
                  thumb-label="always"
                  unity="%"
                  :min="0"
                  :max="40"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-form>
      </v-card>

      <v-card lg12 v-if="nothingFound" class="feedback">
        <v-card-title>
          <div>
            Nenhuma cerveja corresponde a essa pesquisa.
          </div>
          <br />
        </v-card-title>
        <v-card-text v-if="!filtered">
          <router-link :to="{ name: 'Create' }">Clica aqui</router-link> para
          adicionar uma cerveja.
        </v-card-text>
      </v-card>

      <BeerCard v-for="beer in beers" :key="beer.id" :beer="beer" />
    </v-flex>
  </v-container>
</template>
<script>
import BeerCard from "./BeerCard";
import Range from "./RangeComponent";
import Autocomplete from "./Autocomplete";

import { get } from "../infra/ajax";
import debounce from "lodash.debounce";
import ScrollWatch from "scrollwatch";

const maxItems = 20;

export default {
  name: "BeerFinder",
  components: {
    BeerCard,
    Autocomplete,
    Range
  },
  data() {
    return {
      firstload: true,
      pageNumber: 0,
      loading: false,
      loadedAll: false,
      filtered: false,
      query: {
        name: "",
        ingredient: null,
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
  mounted() {
    const watch = new ScrollWatch({
      infiniteScroll: true,
      watch: ".container",
      infiniteOffset: 200,
      onInfiniteYInView: () => {
        this.loadNextPage();
      }
    });
    this.$once("hook:beforeDestroy", () => {
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
      const { loadedAll, loading, pageNumber, query } = this;
      if (loadedAll || loading) {
        return;
      }
      this.loading = true;
      try {
        const { ingredient } = query;
        const ingredientId = !ingredient ? null : ingredient.id;
        const realQuery = { pageNumber, maxItems, ...query, ingredientId };
        const newBeers = await get("Beers", realQuery);
        this.beers.push(...newBeers.results);
        this.loadedAll = newBeers.done;
        this.pageNumber = pageNumber + 1;
      } catch (error) {
        window.console.log(error);
      } finally {
        this.loading = false;
        this.firstload = false;
      }
    },
    loadDebounce: debounce(function() {
      this.filtered = true;
      this.firstload = true;
      this.loadedAll = false;
      this.beers = [];
      this.pageNumber = 0;
      this.loadNextPage();
    }, 750)
  },
  watch: {
    query: {
      deep: true,
      handler() {
        if (this.loading) {
          return;
        }
        this.loadDebounce();
      }
    }
  }
};
</script>
<style lang="sass" scoped>
.search
  width: 100%
  margin-right: 150px

.feedback
  width: 100%
  margin-right: 150px
  display: block
  background-color: rgba(255, 0, 0, 0.4)

.color-picker ::v-deep .v-slider.v-slider--horizontal
  background-image: url(../assets/range-product-color.png)
  background-size: 100% 100%
</style>
