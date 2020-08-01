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
    path: "/beer/:id",
    name: "Beer",
    props: true,
    component: () => import(/* webpackChunkName: "about" */ "../views/Beer.vue")
  }
];

const router = new VueRouter({
  routes
});

export default router;
