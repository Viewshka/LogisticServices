import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

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
]

const router = new VueRouter({
  routes
})

export default router
