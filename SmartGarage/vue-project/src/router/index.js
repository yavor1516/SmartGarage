import { createRouter, createWebHistory } from 'vue-router';

import HomeView from '../views/HomeView.vue';
import LoginView from '../views/Login.vue';
import SignUpView from '../views/SignUp.vue';
import AboutView from '../views/About.vue';
import ProfileView from '../views/Profile.vue';
import DashboardView from '../views/Dashboard.vue';

// Function to check authentication status
function checkAuth() {
    const token = localStorage.getItem('JwtAcessToken');
    return !!token;
}

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
            component: LoginView,
            meta: { requiresAuth: false }
        },
        {
            path: '/signUp',
            name: 'signUp',
            component: SignUpView,
            meta: { requiresAuth: false }
        },
        {
            path: '/about',
            name: 'about',
            component: AboutView,
            meta: { requiresAuth: false }
        },
        {
            path: '/profile',
            name: 'profile',
            component: ProfileView,
            meta: { requiresAuth: true }
        },
        {
            path: '/dashboard',
            name: 'dashboard',
            component: DashboardView,
            meta: { requiresAuth: true }
        }
    ]
});

// Check authentication status before each route navigation
router.beforeEach((to, from, next) => {
    const requiresAuth = to.matched.some(record => record.meta.requiresAuth);

    if (requiresAuth && !checkAuth()) {
        // If the route requires authentication and the user is not authenticated, redirect to the login page
        next('/login');
    } else {
        // Otherwise, proceed with the navigation
        next();
    }
});




export default router;
