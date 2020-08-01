<template>
  <div class="beer">
    <ajax-handler :url="`Beers/${id}`" class="wrapper">
      <template #default="{data}">
        <detail v-bind="{ ...data }" />
      </template>
    </ajax-handler>
  </div>
</template>
<script>
import { ajaxHandler } from "vue-ajax-handler";
import detail from "../components/BeerDetail";
import { get } from "../infra/ajax";

export default {
  name: "Beer",
  props: {
    id: {
      type: String,
      required: true
    }
  },
  provide: {
    get
  },
  components: {
    ajaxHandler,
    detail
  }
};
</script>
<style lang="sass">
.beer ::v-deep .wrapper
  justify-content: center

.beer .wrapper
  display: grid

  *
    justify-self: center
</style>
