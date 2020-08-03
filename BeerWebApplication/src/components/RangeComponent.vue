<template>
  <v-range-slider
    :value="modelValue"
    @input="inputChanged"
    :max="max"
    :min="min"
    :label="label"
    :thumb-label="thumbLabel"
    class="align-center"
  >
    <template v-if="thumbLabel" v-slot:thumb-label="{ value }">
      {{ value }}{{ unity }}
    </template>
  </v-range-slider>
</template>
<script>
export default {
  props: {
    value: {
      type: Object,
      required: true
    },
    max: {
      type: Number,
      required: true
    },
    min: {
      type: Number,
      required: true
    },
    label: {
      type: String
    },
    thumbLabel: {
      default: "always"
    },
    unity: {
      type: String
    }
  },
  computed: {
    modelValue() {
      const {
        value: { min, max }
      } = this;
      return [min, max];
    }
  },
  methods: {
    inputChanged(newValue) {
      const [min, max] = newValue;
      this.$emit("input", { min, max });
    }
  }
};
</script>
<style lang="sass" scoped></style>
