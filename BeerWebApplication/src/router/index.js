import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    props: ({ query }) => ({ query }),
    component: Home
  },
  {
    path: "/about",
    name: "About",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue")
  },
  {
    path: "/beer/create",
    name: "BeerCreate",
    component: () =>
      import(/* webpackChunkName: "create" */ "../views/BeerCreate.vue")
  },
  {
    path: "/beer/:id",
    name: "Beer",
    props: true,
    component: () => import(/* webpackChunkName: "view" */ "../views/Beer.vue")
  },
  {
    path: "/beer/edit/:id",
    name: "BeerEdit",
    props: true,
    component: () =>
      import(/* webpackChunkName: "edit" */ "../views/BeerEdit.vue")
  }
];

const router = new VueRouter({
  routes
});

export default router;
