<template>
  <v-container>
    <v-flex>
      <v-card class="editor">
        <v-form ref="form" v-model="valid">
          <div class="form">
            <v-text-field
              v-model="name"
              label="Nome"
              placeholder="Nome da cerveja"
              :rules="requiredRules"
              required
            />

            <ColorDisplayer v-model="color" :readonly="false" label="Cor" />

            <Range class-="slider temperature"
              v-model="temperature"
              :min="0"
              :max="40"
              label="Temperatura ideal"
              unity="ºC"
            />

            <v-slider class-="slider alcohol"
              v-model="alcoholPercentage"
              label="Teor alcoólico"
              thumb-label="always"
              :min="0"
              :max="40"
            >
              <template v-slot:thumb-label="{ value }"> {{ value }}% </template>
            </v-slider>

            <v-textarea
              v-model="description"
              label="Descripção"
              placeholder="Entra a descripção aqui"
              required
              :rules="requiredRules"
            />

            <v-textarea
              v-model="harmonization"
              label="Harmonização"
              placeholder="Entra a harmonização aqui"
              required
              :rules="requiredRules"
            />

            <v-text-field
              v-model="displayIngredients"
              label="Ingredientes"
              placeholder="Digita aqui os ingredientes separados por virgula"
              :rules="requiredRules"
              required
            />

            <div class="image">
              <v-file-input accept="image/*" label="Imagem"></v-file-input>
              <div>
                <img :src="pictureUrl" v-if="pictureUrl"/>
              </div>
            </div>

          <div class="action">
              <v-btn small color="primary">salvar</v-btn>
            </div>
          </div>
        </v-form>
      </v-card>
    </v-flex>
  </v-container>
</template>
<script>
import Range from "./RangeComponent";
import ColorDisplayer from "./ColorDisplayer";

export default {
  name: "BeerEditor",
  components: {
    Range,
    ColorDisplayer
  },
  props: {
    saveModel: {
      type: Object,
      required: false
    }
  },
  data() {
    const data = {
      requiredRules: [
        v => !!v || 'campo Obrigatório',
      ],
      valid: false
    }
    const { saveModel } = this;
    if (saveModel) {
      return { ...saveModel, ...data };
    }
    return {
      ...data,
      id: null,
      name: "",
      description: "",
      harmonization: "",
      pictureUrl: null,
      color: 50,
      alcoholPercentage: 0,
      temperature: {
        min: 0,
        max: 100
      },
      ingredients: [],
      pictureFile: null
    };
  },
  computed: {
    displayIngredients: {
      get() {
        return this.ingredients.reduce(
          (previous, current) => `${previous}, ${current}`
        , "");
      },
      set(value) {
        this.ingredients = value.split(",").map(ing => ing.replace(/\s/g, ""));
      }
    },
    imageUrl(){
      return this.pictureUrl;
    }
  }
};
</script>
<style lang="sass" scoped>
.form
  display: grid
  grid-template-columns: 1fr 1fr
  grid-template-rows: 80px repeat(3, 100px) repeat(2, 200px) 1fr
  grid-template-areas: "name image" "color image" "temperature image" "alcohol image" "description image" "harmonization image" "ingredient salvar"
  margin: 40px
  align-items: center

  .image
    display: flex
    flex-direction: column
    grid-area: image
    justify-content: flex-end
    justify-self: stretch
    width: 100%
    height: 100%

    img
      //align-items: center
      max-height: 100%
      max-width: 100%
      justify-self: center
      width: auto
      height: auto

  .name
    grid-area: name

  .slider
    display: flex

  .action
    display: flex
    justify-content: flex-end
</style>
