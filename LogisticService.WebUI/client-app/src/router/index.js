import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import simpleLayout from "../layouts/single-card";
import login from "../views/login-form";

import defaultLayout from "../components/static/SideNavOuterToolbar";

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    components: {
      layout: defaultLayout,
      content: Home
    }
  },
  {
    path: "/login-form",
    name: "login-form",
    components: {
      layout: simpleLayout,
      content: login

    },
    props: {
      layout: {
        title: "Sign In"
      }
    }
  },
]

const router = new VueRouter({
  routes
})

export default router
