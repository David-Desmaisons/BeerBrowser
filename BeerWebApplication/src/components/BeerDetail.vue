<template>
  <v-card class="beer-detail">
    <v-dialog v-model="deleteModal" max-width="290">
      <v-card>
        <v-progress-linear
          v-if="deleting"
          indeterminate
          color="blue"
          class="mb-0"
        />

        <v-card-title class="headline">Confirma a exclusão</v-card-title>

        <v-card-text>
          Esse item sera definitivamente excluído.
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn color="green darken-1" text @click="deleteModal = false">
            Cancela
          </v-btn>

          <v-btn color="red darken-1" dark @click="deleteBeer">
            excluir
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-snackbar v-model="showError" :multi-line="multiLine">
      Problema ao excluir a cerveja

      <template v-slot:action="{ attrs }">
        <v-btn color="red" text v-bind="attrs" @click="snackbar = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>

    <div class="name">
      {{ name }}
    </div>

    <div class="description">
      {{ description }}
    </div>

    <div class="harmonization">
      <h2>Harmonização</h2>
      {{ harmonization }}
    </div>

    <div class="ingredients">
      <h2>ingredientes</h2>
      <p>{{ allIngredients }}.</p>
    </div>

    <div class="details">
      <div>
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-icon v-bind="attrs" v-on="on">mdi-thermometer</v-icon>
            {{ temperature.min }} - {{ temperature.max }} ºC
          </template>
          <span>Temperatura ideal</span>
        </v-tooltip>
      </div>

      <div class="alcohol">
        <v-tooltip top>
          <template v-slot:activator="{ on, attrs }">
            <v-icon v-bind="attrs" v-on="on">mdi-percent-outline</v-icon>
            {{ alcoholPercentage }}
          </template>
          <span>Teor alcoólico (% vol)</span>
        </v-tooltip>
      </div>

      <div class="color-picker">
        <v-tooltip bottom>
          <template v-slot:activator="{ on, attrs }">
            <colorDisplayer :value="color" readonly v-bind="attrs" v-on="on" />
          </template>
          <span>Cor</span>
        </v-tooltip>
      </div>
    </div>

    <div class="actions">
      <v-tooltip top>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="primary"
            fab
            small
            :to="{ name: 'Edit', params: { id: `${id}` } }"
            v-bind="attrs"
            v-on="on"
          >
            <v-icon>mdi-pencil</v-icon>
          </v-btn>
        </template>
        <span>Editar cerveja</span>
      </v-tooltip>

      <v-tooltip top>
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="secondary"
            fab
            small
            @click="deleteModal = true"
            v-bind="attrs"
            v-on="on"
          >
            <v-icon>mdi-delete</v-icon>
          </v-btn>
        </template>
        <span>Excluir cerveja</span>
      </v-tooltip>
    </div>

    <img class="image" :src="pictureUrl" alt="foto" />
  </v-card>
</template>
<script>
import colorDisplayer from "./ColorDisplayer";
import { deleteAjax } from "../infra/ajax";

const createProps = (type, names) =>
  names
    .map(name => ({ [name]: { type } }))
    .reduce((previous, current) => ({ ...previous, ...current }), {});

export default {
  props: {
    ingredients: {
      type: Array
    },
    temperature: {
      type: Object
    },
    ...createProps(String, [
      "name",
      "description",
      "harmonization",
      "pictureUrl"
    ]),
    ...createProps(Number, ["id", "alcoholPercentage", "color"])
  },
  components: {
    colorDisplayer
  },
  computed: {
    allIngredients() {
      return this.ingredients.reduce(
        (previous, current) => `${previous}, ${current}`
      );
    }
  },
  data() {
    return {
      deleteModal: false,
      deleting: false,
      showError: false
    };
  },
  methods: {
    async deleteBeer() {
      this.deleting = true;
      try {
        await deleteAjax(`Beers/${this.id}`);
        this.$router.push({ name: "Home" });
      } catch {
        this.showError = true;
      }
      this.deleting = false;
      this.deleteModal = false;
    }
  }
};
</script>
<style lang="sass" scoped>
.beer-detail
  margin-top: 20px
  max-width: 1090px
  display: grid
  grid-template-columns: minmax(auto, 1fr) 2fr 300px
  grid-template-rows: 120px 320px 60px
  grid-template-areas: "name image harmonization" "description image details" "ingredients image actions"
  column-gap: 10px
  row-gap: 10px
  padding: 10px 10px 10px 10px

  @media screen and (max-width: 1100px)
    grid-template-columns: 1fr 1fr
    grid-template-rows: 120px 140px 100px 100px auto 60px
    grid-template-areas: "name image" "description image" "harmonization image" "ingredients image" "details image" "details actions"

  @media screen and (max-width: 900px)
    grid-template-columns: 1fr
    grid-template-rows: 120px 440px 140px 100px 100px auto 60px
    grid-template-areas: "name" "image" "description" "harmonization" "ingredients" "details" "actions"

  *
    align-self: center

  .image
    grid-area: image
    max-height: 100%
    max-width: 100%
    justify-self: center
    width: auto
    height: auto

  .name
    grid-area: name
    font-size: 71px
    font-weight: bold

  .description
    grid-area: description

  .ingredients
    grid-area: ingredients
    ::first-letter
      text-transform: capitalize

  .harmonization
    grid-area: harmonization
    margin-right: 20px

  .actions
    grid-area: actions
    display: flex
    justify-content: flex-end
    margin-right: 20px
    *
      margin: 10px

  .details
    grid-area: details
    display: grid
    grid-template-columns: 1fr 1fr
    grid-template-rows: 1fr 1fr
    grid-template-areas: "temperature degree" "color color"
    text-align: left
    margin-right: 20px
    align-self: stretch

    @media screen and (max-width: 1100px)
      grid-template-columns: 1fr 2fr 1fr
      grid-template-rows: 1fr
      grid-template-areas: "temperature color degree"

    .color-picker
      grid-area: color

    .alcohol
      text-align: right
</style>
