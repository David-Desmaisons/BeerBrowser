<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <div class="d-flex align-center">
        <img class="icon" alt="cerveja" src="../public/noun_Beer_390552.svg" />

        Catálogo de Cervejas
      </div>
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
  })
};
</script>
<style lang="sass" scoped>
.icon
  width: 30px
</style>
