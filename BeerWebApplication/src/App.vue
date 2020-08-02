<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <img class="icon" alt="cerveja" src="../public/noun_Beer_390552.svg" />

        Catálogo de Cervejas
      </div>

      <v-spacer></v-spacer>

      <v-btn icon :to="{ name: 'Home' }" @click="scrollToTop">
        <v-icon>mdi-magnify</v-icon>
      </v-btn>

      <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
          <v-btn icon :to="{ name: 'Create' }" v-bind="attrs" v-on="on">
            <v-icon>mdi-plus</v-icon>
          </v-btn>
        </template>
        <span>Adicionar nova cerveja</span>
      </v-tooltip>
    </v-app-bar>

    <v-main class="content">
      <router-view :key="$route.fullPath"></router-view>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: "App",
  data: () => ({
    //
  }),
  methods: {
    scrollToTop() {
      window.scrollTo(0, 0);
    }
  }
};
</script>
<style lang="sass" scoped>
.icon
  width: 30px
</style>
