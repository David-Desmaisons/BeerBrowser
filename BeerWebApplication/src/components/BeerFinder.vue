<template>
  <v-container>
    <v-flex lg12 xs8 offset-xs2 row wrap class="mt-5 mb-5">
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
  </v-container>
</template>
<script>
import { get } from "../infra/ajax";
import BeerCard from "./BeerCard";
import ScrollWatch from "scrollwatch";
const pageLength = 20;

export default {
  name: "BeerFinder",
  components: {
    BeerCard
  },
  data() {
    return {
      firstload: true,
      pageNumber: 0,
      loading: false,
      loadedAll: false,
      beers: []
    };
  },
  async created() {
    await this.loadNextPage();
    this.firstload = false;
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
        const query = { pageNumber, pageLength };
        const newBeers = await get("Beers", query);
        this.beers.push(...newBeers.results);
        this.loadedAll = newBeers.done;
        this.pageNumber = pageNumber + 1;
        this.loading = false;
      } catch (error) {
        window.console.log(error);
      }
    }
  }
};
</script>
