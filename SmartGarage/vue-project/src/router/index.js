import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/Login.vue'
import SignUpView from '../views/SignUp.vue'
import AboutView from '../views/About.vue'
import ProfileView from '../views/Profile.vue'
import DashboardView from '../views/Dashboard.vue'

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
            meta: { requiresAuth: false } // Indicates that this route does not require authentication
        },
        {
            path: '/signUp',
            name: 'signUp',
            component: SignUpView,
            meta: { requiresAuth: false } // Indicates that this route does not require authentication
        },
        {
            path: '/about',
            name: 'about',
            component: AboutView,
            meta: { requiresAuth: false } // Indicates that this route does not require authentication
        },
        {
            path: '/profile',
            name: 'profile',
            component: ProfileView,
            meta: { requiresAuth: true } // Indicates that this route requires authentication
        },
        {
            path: '/dashboard',
            name: 'dashboard',
            component: DashboardView,
            meta: { requiresAuth: true } // Indicates that this route requires authentication
        }
    ]
})

// Check authentication status before each route navigation
router.beforeEach((to, from, next) => {
    const isAuthenticated = checkAuth(); // Implement your authentication check logic here
    const requiresAuth = to.matched.some(record => record.meta.requiresAuth);

    if (requiresAuth && !isAuthenticated) {
        // If route requires authentication and user is not authenticated, redirect to login
        next('/login');
    } else {
        // Otherwise, proceed with the navigation
        next();
    }
});

function checkAuth() {
    // Implement your authentication check logic here
    // For example, you can check if the user is logged in by checking if there is a token in local storage
    const token = localStorage.getItem('JwtAcessToken');
    return !!token; // Return true if token exists, indicating the user is authenticated
}

export default router
