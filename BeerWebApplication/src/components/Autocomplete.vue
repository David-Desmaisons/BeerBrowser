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
    item-text="name"
    item-value="API"
    :label="label"
    :placeholder="placeholder"
    return-object
  ></v-autocomplete>
</template>
<script>
import { get } from "../infra/ajax";

export default {
  name: "autocomplete",
  props: {
    value: {
      type: Object
    },
    placeholder: {
      type: String,
      required: true
    },
    label: {
      type: String,
      required: true
    },
    url: {
      type: String,
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
    input(value) {
      window.console.log(value);
      this.$emit("input", value);
    }
  },
  computed: {
    items() {
      return this.entries;
    }
  },
  watch: {
    async search() {
      const { items, isLoading, url } = this;
      if (items.length > 0 || isLoading) {
        return;
      }
      this.isLoading = true;

      try {
        const result = await get(url);
        this.entries = result;
      } finally {
        this.isLoading = false;
      }
    }
  }
};
</script>
