<template>
  <div class="edit">
    <ajax-handler :url="`Beers/${id}`" class="wrapper">
      <template #default="{data}">
        <editor :saveModel="{ ...data }" />
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
import editor from "../components/BeerEditor";

export default {
  name: "Beer-Edit",
  props: {
    id: {
      type: String,
      required: true
    }
  },
  components: {
    ajaxHandler,
    editor
  }
};
</script>
<style lang="sass" scoped>
.edit .wrapper
  display: grid

  *
    justify-self: center

  ::v-deep .v-skeleton-loader__image
    height: 500px
</style>
