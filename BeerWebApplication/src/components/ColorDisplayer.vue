<template>
  <div class="color-displayer">
    <v-slider
      :value="value"
      :readonly="readonly"
      @input="change(evt)"
      dense
      min="0"
      max="100"/>
  </div>
</template>
<script>
export default {
  props: {
    readonly: {
      type: Boolean,
      default: true
    },
    value: {
      type: Number,
      required: true
    }
  },
  methods: {
    change(value) {
      this.$emit("input", value);
    }
  }
};
</script>
<style lang="sass" scoped>
.color-displayer
  width: 100%

  ::v-deep .v-slider.v-slider--horizontal
    background-image: url(../assets/range-product-color.png)
    background-size: 100% 100%
</style>