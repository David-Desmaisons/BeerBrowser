<template>
  <div class="about">
    <ajax-handler :url="`Beers/${id}`">
      <template #default="{data}">
        <detail v-bind="{ ...data }" />
        <!-- :data="data" -->
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
