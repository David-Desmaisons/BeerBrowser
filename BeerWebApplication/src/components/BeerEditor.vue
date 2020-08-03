<template>
  <v-container>
    <v-flex>
      <v-card class="editor mx-auto" max-width="800">
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

            <Range
              class-="slider temperature"
              v-model="temperature"
              :min="0"
              :max="40"
              label="Temperatura ideal"
              unity="ºC"
            />

            <v-slider
              class-="slider alcohol"
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
              <v-file-input
                accept="image/*"
                label="Foto"
                prepend-icon="mdi-camera"
                :rules="pictureUrl ? [] : requiredRules"
                v-model="fileUpload"
              ></v-file-input>
              <div class="image-container">
                <img :src="pictureUrl" v-if="pictureUrl" />
              </div>
            </div>

            <div class="action">
              <v-btn small color="primary" :disabled="!valid" @click="save"
                >salvar</v-btn
              >
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
import { put, post } from "../infra/ajax";

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
      requiredRules: [v => !!v || "campo Obrigatório"],
      valid: false,
      fileUpload: null
    };
    const { saveModel } = this;
    if (saveModel) {
      return { ...saveModel, ...data, valid: true };
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
      ingredients: []
    };
  },
  computed: {
    displayIngredients: {
      get() {
        const { ingredients } = this;
        return ingredients.length === 0
          ? ""
          : ingredients.reduce(
              (previous, current) => `${previous}, ${current}`
            );
      },
      set(value) {
        this.ingredients = value.split(",").map(ing => ing.replace(/\s/g, ""));
      }
    }
  },
  watch: {
    fileUpload(value) {
      if (value === null) {
        return;
      }
      const reader = new FileReader();
      reader.onload = e => {
        this.pictureUrl = e.target.result;
      };
      reader.readAsDataURL(value);
    }
  },
  methods: {
    getFormData() {
      const {
        description,
        fileUpload,
        harmonization,
        name,
        alcoholPercentage,
        color,
        ingredients,
        temperature
      } = this;
      const formData = new FormData();
      formData.append("picture", fileUpload);
      formData.append("description", description);
      formData.append("name", name);
      formData.append("harmonization", harmonization);
      formData.append("alcoholPercentage", alcoholPercentage);
      formData.append("color", color);
      formData.append("ingredients", JSON.stringify(ingredients));
      formData.append("temperature", JSON.stringify(temperature));
      return formData;
    },
    async save() {
      const { id, saveModel } = this;
      const verb = saveModel
        ? data => put(`Beers/${id}`, data)
        : data => post("Beers", data);
      const formData = this.getFormData();
      try {
        await verb(formData);
      } finally {
        this.$router.push({ name: "Home" });
      }
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

    .image-container
      flex-grow: 2

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
