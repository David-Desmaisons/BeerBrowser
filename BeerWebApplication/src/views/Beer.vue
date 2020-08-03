<template>
  <div class="beer">
    <ajax-handler :url="`Beers/${id}`" class="wrapper">
      <template #default="{data}">
        <detail v-bind="{ ...data }" />
      </template>

      <template #loading>
        <v-skeleton-loader
          class="boiler-plate"
          width="1090"
          height="550"
          type="card-avatar"
        />
      </template>
    </ajax-handler>
  </div>
</template>
<script>
import { ajaxHandler } from "vue-ajax-handler";
import detail from "../components/BeerDetail";

export default {
  name: "Beer",
  props: {
    id: {
      type: String,
      required: true
    }
  },
  components: {
    ajaxHandler,
    detail
  }
};
</script>
<style lang="sass" scoped>
.beer .wrapper
  display: grid

  *
    justify-self: center

  ::v-deep .v-skeleton-loader__image
    height: 500px
</style>
