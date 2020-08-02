<template>
  <v-autocomplete
    :value="value"
    @input="input"
    :items="items"
    :loading="isLoading"
    :search-input.sync="search"
    color="white"
    hide-no-data
    hide-selected
    item-text="Description"
    item-value="API"
    :label="label"
    :placeholder="placeholder"
    return-object
  ></v-autocomplete>
</template>
<script>
export default {
  name: "autocomplete",
  props: {
    value: {
      type: Object,
      required: true
    },
    placeholder: {
      type: Object,
      required: true
    },
    label: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      entries: [],
      isLoading: false,
      search: null
    };
  },
  methods: {
    input() {}
  },
  computed: {
    items() {
      return this.entries;
    }
  }
};
</script>
