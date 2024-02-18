import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
   
      {
          path: '/login',
          name: 'login',
          component: () => import('../views/Login.vue')
      }, {
          path: '/signUp',
          name: 'signUp',
          component: () => import('../views/SignUp.vue')
      }
      , {
          path: '/about',
          name: 'about',
          component: () => import('../views/About.vue')
      }
      , {
          path: '/profile',
          name: 'profile',
          component: () => import('../views/Profile.vue')
      }
  ]
})

export default router
